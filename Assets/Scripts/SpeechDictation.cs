using UnityEngine;
using UnityEngine.UI;
using Microsoft.CognitiveServices.Speech;
using System;
public class SpeechDictation : MonoBehaviour
{
    public Text outputText;
    //public Button startButton;
    //public Button stopButton;

    private object threadLocker = new object();
    private string message = String.Empty;

    private SpeechRecognizer recognizer;

    private void Start()
    {
        //startButton.onClick.AddListener(StartButton);
        //stopButton.onClick.AddListener(StopButton);
    }
    public void StartButton()
    {
        StartContinuousRecognition();
    }

    private async void StartContinuousRecognition()
    {
        CreateSpeechRecognizer();

        if (recognizer != null)
        {
            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
        }
    }

    public void CreateSpeechRecognizer()
    {
        var config = SpeechConfig.FromSubscription("1553d8e640714a9796414c6322dcf719", "westus");

        recognizer = new SpeechRecognizer(config);

        if (recognizer != null)
        {
            recognizer.Recognizing += RecognizingHandler;
            recognizer.Recognized += RecognizedHandler;
        }
    }

    public async void StopRecognition()
    {
        if (recognizer != null)
        {
            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            recognizer.Recognizing -= RecognizingHandler;
            recognizer.Recognized -= RecognizedHandler;
            recognizer.Dispose();
            recognizer = null;
        }
    }

    private void RecognizingHandler(object sender, SpeechRecognitionEventArgs e)
    {
        if (e.Result.Reason == ResultReason.RecognizingSpeech)
        {
            lock (threadLocker)
            {
                message = e.Result.Text;
            }
        }
    }

    private void RecognizedHandler(object sender, SpeechRecognitionEventArgs e)
    {
        if (e.Result.Reason == ResultReason.RecognizedSpeech)
        {
            lock (threadLocker)
            {
                message = e.Result.Text;
            }
        }
        else if (e.Result.Reason == ResultReason.NoMatch)
        {
            message = "Speech could not be recognized.";
        }
    }

    public void StopButton()
    {
        StopRecognition();
    }



    void Update()
    {
        if (!String.IsNullOrEmpty(message))
        {
            lock (threadLocker)
            {
                outputText.text = message;
            }
            message = String.Empty;
        }
    }
}
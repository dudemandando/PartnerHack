using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

public class AttachToHand : MonoBehaviour
{
    public GameObject debugCube;
    IMixedRealityHandJointService jointService;
    IMixedRealityHand hnd;
    Handedness handness;
   
    // Start is called before the first frame update
    void Start()
    {
        jointService = MixedRealityToolkit.Instance.GetService<IMixedRealityHandJointService>();
        if(jointService != null)
            debugCube.GetComponent<TextMeshPro>().text = "== " + jointService.IsHandTracked(Handedness.Right);
    }
        //handTrackingProfile = MixedRealityToolkit.Instance.ActiveProfile.InputSystemProfile.HandTrackingProfile;
        //if (handTrackingProfile != null)
        //{
        //    Debug.Log("dsa");
        //    debugCube.SetActive(true);
        //    handTrackingProfile.EnableHandJointVisualization = false;
        //    handTrackingProfile.EnableHandMeshVisualization = false;
        //}

    void Update()
    {
        if (jointService != null)
        {
            debugCube.GetComponent<TextMeshPro>().text = "== " + jointService.IsHandTracked(Handedness.Right) + "  --- " + jointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right);
            //jointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right);
        }
    }
}

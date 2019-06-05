using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleIntrestPointCanvas : MonoBehaviour
{
    public GameObject canvasToToggle;
    public Color defaultImageBackgroundColor;
    public Color highlightImageBackgroundColor;
    public Image backgroundImage;

    public void ToggleCanvas()
    {
        if (canvasToToggle.activeInHierarchy)
            canvasToToggle.SetActive(false);
        else
            canvasToToggle.SetActive(true);
    }

    public void HighlightImageBackground()
    {
        backgroundImage.color = highlightImageBackgroundColor;
    }

    public void defaultImageBackground()
    {
        backgroundImage.color = defaultImageBackgroundColor;
    }
}

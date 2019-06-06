using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ToggleMapInteraction : MonoBehaviour
{
    public ManipulationHandler manipHandler;
    public BoundingBox boundBox;
    public BoxCollider boxCol;

    private bool bToggleState = true;

    void Start()
    {
        ToggleMap();
    }

    public void ToggleMap()
    {
        if(bToggleState == true)
        {
            manipHandler.enabled = false;
            boundBox.enabled = false;
            boxCol.enabled = false;

            bToggleState = false;
        }
        else
        {
            manipHandler.enabled = true;
            boundBox.enabled = true;
            boxCol.enabled = true;

            bToggleState = true;
        }
    }
}

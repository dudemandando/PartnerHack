using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechHandlers : MonoBehaviour
{
    public ToggleMapInteraction terrainWithManupulator;

    public void StartTransform()
    {
        if(terrainWithManupulator != null)
            terrainWithManupulator.ToggleMap();
    }

    public void StopTransform()
    {
        if (terrainWithManupulator != null)
            terrainWithManupulator.ToggleMap();
    }

    public void Konichiwa()
    {
        if (terrainWithManupulator != null)
            terrainWithManupulator.PlayParticleSys();
    }
}

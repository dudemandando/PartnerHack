using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLineDots : MonoBehaviour
{
    Material material;
    [Tooltip("Higher the number, slower the speed")]
    public int speedFactor = 4;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        var val = Time.time / 3;
        material.SetFloat("_Offset", val);
    }
}
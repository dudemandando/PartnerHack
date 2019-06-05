using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material tealMat;

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material = tealMat;
    }

    public void ChangeToRed()
    {
        mr.material = redMat;
    }

    public void ChangeToBlue()
    {
        mr.material = blueMat;
    }

    public void ChangeToGreen()
    {
        mr.material = greenMat;
    }

}

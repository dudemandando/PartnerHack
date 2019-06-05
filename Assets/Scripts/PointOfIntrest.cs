using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOfIntrest : MonoBehaviour
{

    public Type pointType;
    public GameObject terrainRefPoint; //Ghost reference point to be attached to the Terrain
    public Image iconImage;
    public Image bgImage;
    public Color normalColor;
    public Color highlightColor;
    public float heightStandOff;
    

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
    }

    public void initPoint(string initType, Sprite iconSprite)
    {

        switch (initType)
        {
            case "Airplane":
                pointType = Type.Airplane;
                break;
            case "Blocked":
                pointType = Type.Blocked;
                break;
            case "Boat":
                pointType = Type.Blocked;
                break;
            case "Car":
                pointType = Type.Blocked;
                break;
            case "Electrical":
                pointType = Type.Electrical;
                break;
            case "FireFighter":
                pointType = Type.FireFighter;
                break;
            case "Helicopter":
                pointType = Type.Helicopter;
                break;
            case "Medical":
                pointType = Type.Medical;
                break;

        }
        
        iconImage.sprite = iconSprite;
    }

    public void AddHeightStandoff()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + heightStandOff, this.transform.position.z);
    }
}

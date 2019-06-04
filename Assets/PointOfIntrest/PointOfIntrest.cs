using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOfIntrest : MonoBehaviour
{

    public Type pointType;
    public GameObject terrainRefPoint; //Ghost reference point to be attached to the Terrain
    private Image iconImage;
    private Image bgImage;
    public Color normalColor;
    public Color highlightColor;
    
    // Start is called before the first frame update
    void Start()
    {
        iconImage = transform.Find("Canvas").Find("IconImage").GetComponent<Image>();
        bgImage = transform.Find("Canvas").Find("Bg").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void initPoint(string initType, Sprite iconSprite)
    {
        iconImage = transform.Find("Canvas").Find("IconImage").GetComponent<Image>();
        bgImage = transform.Find("Canvas").Find("Bg").GetComponent<Image>();

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
}

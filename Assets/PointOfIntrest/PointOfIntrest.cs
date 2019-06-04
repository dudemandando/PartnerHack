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
        
    }

    public void initPoint(Type initType)
    {

    }
}

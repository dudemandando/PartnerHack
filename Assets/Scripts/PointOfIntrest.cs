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

    public GameObject[] iconModels;

    private bool bPropogatedOnce = false;
    

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
    }

    void OnEnable()
    {
        initPoint(pointType);
    }


    public void initPoint(Type initType)
    {

        switch (initType)
        {
            case Type.Airplane:
                iconModels[0].SetActive(true);
                break;
            case Type.Blocked:
                iconModels[1].SetActive(true);
                break;
            case Type.Boat:
                iconModels[2].SetActive(true);
                break;
            case Type.Car:
                iconModels[3].SetActive(true);
                break;
            case Type.Electrical:
                iconModels[4].SetActive(true);
                break;
            case Type.FireFighter:
                iconModels[5].SetActive(true);
                break;
            case Type.Helicopter:
                iconModels[6].SetActive(true);
                break;
            case Type.Medical:
                iconModels[7].SetActive(true);
                break;

        }
        
        //iconImage.sprite = iconSprite;
    }

    public void AddHeightStandoff()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + heightStandOff, this.transform.position.z);
    }

    public void SpawnReplacement()
    {
        if(bPropogatedOnce == false)
        {
            var replace = Instantiate(this.gameObject, transform.position, Quaternion.identity, this.transform.parent);
        }

        bPropogatedOnce = true;        
    }
}

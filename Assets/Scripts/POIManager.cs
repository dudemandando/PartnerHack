using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    None,
    Airplane,
    Blocked,
    Boat,
    Car,
    Electrical,
    FireFighter,
    Helicopter,
    Medical
}

public class POIManager : MonoBehaviour
{
    public GameObject pointPrefab;
    public List<PointOfIntrest> allInterestPoints;
    public List<Sprite> iconImages;
    public Transform testTransform;
    public TerrainManager terrainManager;


    //float lat = 37.318508f;
    //float lng = 141.037956f;

    // Start is called before the first frame update
    void Start()
    {
        createPointOfInterest("Radiation", testTransform, 37.318508f, 141.037956f);
    }

  
    public void createPointOfInterest(string spawnType, Transform spawnPoint, float lat, float lng)
    {
        GameObject spawnedPoint = Instantiate(pointPrefab, terrainManager.SetPointLocationFromLatLong(lat, lng), Quaternion.identity);
        

        foreach (Sprite sp in iconImages)
        {
            if(sp.name.ToString() == spawnType)
            {
                spawnedPoint.GetComponent<PointOfIntrest>().initPoint(spawnType, sp);
            }
        }
        
        spawnedPoint.GetComponent<PointOfIntrest>().AddHeightStandoff();
    }
}

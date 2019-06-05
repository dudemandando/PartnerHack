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
        //Spawn the point of intrest at the appropriate Lat and Long passed in
        GameObject spawnedPoint = Instantiate(pointPrefab, terrainManager.SetPointLocationFromLatLong(lat, lng), Quaternion.identity);
        

        //loop thorugh all the sprites and find the appropriate one via sprite name
        foreach (Sprite sp in iconImages)
        {
            if(sp.name.ToString() == spawnType)
            {
                spawnedPoint.GetComponent<PointOfIntrest>().initPoint(spawnType, sp);
            }
        }
        
        //Add a little standoff from the terrain
        spawnedPoint.GetComponent<PointOfIntrest>().AddHeightStandoff();

        //Add to the list of all points of interest
        allInterestPoints.Add(spawnedPoint.GetComponent<PointOfIntrest>());

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Type
{
    None,
    Accident,
    Airplane,
    Blocked,
    Ferry,
    Fire,
    Health,
    People,
    Unknown,
    Warning,
    Wind
}

public class POIManager : MonoBehaviour
{
    public GameObject pointPrefab;
    public List<GameObject> allInterestPoints;
    public List<Sprite> iconImages;
    public TerrainManager terrainManager;

    //Point Display stuff
    public GameObject rowContainer;
    public GameObject row;
    public List<GameObject> modelIcons;


    //float lat = 37.318508f;
    //float lng = 141.037956f;

    // Start is called before the first frame update
    void Start()
    {
        //createPointOfInterest("Radiation", testTransform, 37.318508f, 141.037956f);
        
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
                //spawnedPoint.GetComponent<PointOfIntrest>().initPoint(Type.Medical);
            }
        }
        
        //Add a little standoff from the terrain
        spawnedPoint.GetComponent<PointOfIntrest>().AddHeightStandoff();

        //Add to the list of all points of interest
        allInterestPoints.Add(spawnedPoint);

    }

    public void AddPoint(PointOfIntrest point)
    {

        if (!allInterestPoints.Contains(point.gameObject))
        {
            //creates the new row
            allInterestPoints.Add(point.gameObject);
            CreateRowInDisplay(point, allInterestPoints.IndexOf(point.gameObject));
        }
        else
        {
            //updates the lat and long
            UpdateRow(point);
        }

    }

    public void RemovePoint(PointOfIntrest point)
    {
        allInterestPoints.Remove(point.gameObject);
    }

    public void CreateRowInDisplay(PointOfIntrest point, int idx)
    {
        GameObject newRow = Instantiate(row, rowContainer.transform);
        point.rowObj = newRow;

        //Set the index number
        newRow.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = idx.ToString();

        //Set the Image
        newRow.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = RetrieveIconSprite(point);

        //Set the type
        newRow.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = point.pointType.ToString();

        //needs to call the GetLatLong(Vector3 otherPos) in Terrain Manager
        LatLong newlatLong = terrainManager.GetLatLong(point.transform.position);

        ////Set Lat
        newRow.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = newlatLong.lat.ToString();

        ////Set Long
        newRow.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = newlatLong.lng.ToString();
    }

    //updates the lat long text
    public void UpdateRow(PointOfIntrest point)
    {
        //needs to call the GetLatLong(Vector3 otherPos) in Terrain Manager
        LatLong newlatLong = terrainManager.GetLatLong(point.transform.position);

        //Set Lat
        point.rowObj.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = newlatLong.lat.ToString();

        //Set Long
        point.rowObj.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = newlatLong.lng.ToString();
    }

    //loops through all images to find the correct one for the row to display
    //private Sprite RetrieveProperIconSprite(Type type)
    //{
    //    foreach(Sprite sp in iconImages)
    //    {
    //        if(sp.name == type.ToString())
    //        {
    //            return sp;
    //        }
    //    }

    //    return null;
    //}

    private Sprite RetrieveIconSprite(PointOfIntrest point)
    {
        Sprite sp;
        switch (point.pointType)
        {
            case Type.Accident:
                sp = iconImages[0];
                break;
            case Type.Airplane:
                sp = iconImages[1];
                break;
            case Type.Blocked:
                sp = iconImages[2];
                break;
            case Type.Ferry:
                sp = iconImages[3];
                break;
            case Type.Health:
                sp = iconImages[4];
                break;
            case Type.People:
                sp = iconImages[5];
                break;
            case Type.Unknown:
                sp = iconImages[6];
                break;
            case Type.Warning:
                sp = iconImages[7];
                break;
            case Type.Wind:
                sp = iconImages[8];
                break;
            case Type.Fire:
                sp = iconImages[9];
                break;
            default:
                Debug.Log("No icon found");
                sp = null;
                break;
        }
        return sp;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainManager : MonoBehaviour
{

    //N: 37.347
    //W: 140.986
    //E: 141.048
    //S: 37.297

    //public float lowLat = 37.297f;
    //public float highLat = 37.347f;
    //public float lowLong = 140.986f;
    //public float highLong = 141.048f;

    public float lowLat = 0f;
    public float highLat = 1f;
    public float lowLong = 0f;
    public float highLong = 1f;


    public Bounds terrainBounds;
    public float LowX { get; set; }
    public float HighX { get; set; }
    public float LowZ { get; set; }
    public float HighZ { get; set; }

    public GameObject testObj;


    //Make sure to call this anytime we scale or move
    public void GetBounds()
    {
        //Calculate terrain model boundaries for conversion
        terrainBounds = GetComponent<MeshFilter>().mesh.bounds;

        LowX = terrainBounds.center.x - terrainBounds.extents.x;
        HighX = terrainBounds.center.x + terrainBounds.extents.x;
        LowZ = terrainBounds.center.z - terrainBounds.extents.z;
        HighZ = terrainBounds.center.z + terrainBounds.extents.z;

    }

    public Vector3 SetPointLocationFromLatLong(float lat, float lng)
    {
        GetBounds();
        Debug.Log("Running test with lat and long of: " +  lat + " "+ lng);
        //37.318508, 141.037956

        float newX, newZ;
        
        newZ = -1 * lat.Remap(lowLat, highLat, LowZ, HighZ);
        newX = -1 * lng.Remap(lowLong, highLong, LowX, HighX);
        Debug.Log(newZ + " " + newX);
        Debug.Log("New Location should be: " + this.transform.TransformPoint(new Vector3(newX, 0.02f, newZ)));
        return this.transform.TransformPoint(new Vector3(newX, 0.02f, newZ));

    }

    public LatLong GetLatLong(Vector3 otherPos)
    {
        Debug.Log("Getting Position in Lat & Long");
        GetBounds();
        
        float newX, newZ;

        newZ = -1 * otherPos.z.Remap(lowLat, highLat, LowZ, HighZ);
        newX = -1 * otherPos.x.Remap(lowLong, highLong, LowX, HighX);


        LatLong pos = new LatLong(newZ, newX);
        return pos;
    }
}

public class LatLong
{
    public float lat;
    public float lng;

    public LatLong(float lat, float lng)
    {
        this.lat = lat;
        this.lng = lng;
    }
}

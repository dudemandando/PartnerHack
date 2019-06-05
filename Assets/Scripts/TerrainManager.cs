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


    // Start is called before the first frame update
    void Start()
    {
        GetBounds();
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


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

    public void test()
    {
        Debug.Log("Running test");
        //37.318508, 141.037956

        float newX, newZ;
        float lat = 37.318508f;
        float lng = 141.037956f;

        newZ = -1 * lat.Remap(lowLat, highLat, LowZ, HighZ);
        newX = -1 * lng.Remap(lowLong, highLong, LowX, HighX);

        testObj.transform.position = this.transform.TransformPoint(new Vector3(newX, 0.02f, newZ));

    }
}

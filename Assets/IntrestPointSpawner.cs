using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrestPointSpawner : MonoBehaviour
{
    public Type disasterType;
    public GameObject pointOfIntrestPrefab;

    void Start()
    {
        GameObject tempPrefab = Instantiate(pointOfIntrestPrefab, this.transform.position, Quaternion.identity);
        tempPrefab.transform.parent = this.transform;
        tempPrefab.GetComponent<PointOfIntrest>().pointType = disasterType;
        tempPrefab.GetComponent<PointOfIntrest>().initPoint(disasterType);
    }
}

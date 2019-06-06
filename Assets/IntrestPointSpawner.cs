using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrestPointSpawner : MonoBehaviour
{
    public Type disasterType;

    void Start()
    {
        GameObject tempPrefab = Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
        tempPrefab.transform.parent = this.transform;
        tempPrefab.GetComponent<PointOfIntrest>().pointType = disasterType;
        tempPrefab.GetComponent<PointOfIntrest>().initPoint(disasterType);
    }
}

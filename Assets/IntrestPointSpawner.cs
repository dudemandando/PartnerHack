using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrestPointSpawner : MonoBehaviour
{
    public GameObject intrestPointPrefab;

    void Start()
    {
        var tempPrefab = Instantiate(intrestPointPrefab, this.transform.position, Quaternion.identity);
        tempPrefab.transform.parent = this.transform;
    }
}

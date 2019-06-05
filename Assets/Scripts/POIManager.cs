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
    
    // Start is called before the first frame update
    void Start()
    {
        createPointOfInterest("Airplane", testTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPointOfInterest(string spawnType, Transform spawnPoint)
    {
        GameObject spawnedPoint = Instantiate(pointPrefab);
        spawnedPoint.transform.position = testTransform.position;

        foreach (Sprite sp in iconImages)
        {
            if(sp.name.ToString() == spawnType)
            {
                spawnedPoint.GetComponent<PointOfIntrest>().initPoint(spawnType, sp);
            }
        }
    }
}

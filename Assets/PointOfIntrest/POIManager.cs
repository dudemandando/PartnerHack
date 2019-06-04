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
    Confirm,
    Electrical,
    Exit,
    FireFighter,
    Helicopter,
    MapPin,
    Medical
}

public class POIManager : MonoBehaviour
{
    public List<PointOfIntrest> allInterestPoints;
    public List<Sprite> iconImages;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPointOfInterest()
    {

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class PlaceOnMap : MonoBehaviour
{
    public LineRenderer lr;
    public LayerMask layerToCheck;
    public AudioSource audioSrc;
    public AudioClip snapToMapClip;
    public AudioClip destroyClip;
    
    //private Vector3 defaultScale;
    //public Vector3 smallScaleVal;

    private float t = 0;
    private RaycastHit hit;

    private bool isBeingManipulated = false;



    public void ShowLinePlacement()
    {
        isBeingManipulated = true;
        lr.enabled = true;
    }

    public void SnapToMap()
    {
        isBeingManipulated = false;
        //lr.enabled = false;
        GetComponent<BoundingBox>().UnhighlightWires();

        if (hit.transform != null)
        {
            audioSrc.PlayOneShot(snapToMapClip);
            //transform.position = hit.point;
            this.gameObject.GetComponent<PointOfIntrest>().AddToPOIList();
        }            
        else
        {
            audioSrc.PlayOneShot(destroyClip);
            //this.gameObject.SetActive(false);
            this.gameObject.GetComponent<PointOfIntrest>().RemoveFromPOIList();
            Destroy(this.gameObject.GetComponent<PointOfIntrest>().rowObj);
            Destroy(this.gameObject);
        }
            
    }

    void Update()
    {
        if(isBeingManipulated)
        {
            // Does the ray intersect with map
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerToCheck))
            {
                lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));

                if (t < 1f)
                    t += Time.deltaTime * 1.45f;

                float hitLerpY = Mathf.Lerp(transform.position.y, hit.point.y, t);
                lr.SetPosition(1, new Vector3(transform.position.x, hitLerpY, transform.position.z));
            }
            else
            {
                t = 0;
                lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                lr.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z));
            }
        }        
    }

}

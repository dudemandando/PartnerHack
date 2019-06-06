using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnMap : MonoBehaviour
{
    public LineRenderer lr;
    public LayerMask layerToCheck;
    public AudioSource audioSrc;
    public AudioClip snapToMapClip;
    public AudioClip destroyClip;

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
        lr.enabled = false;

        if (hit.transform != null)
        {
            audioSrc.PlayOneShot(snapToMapClip);
            transform.position = hit.point;
        }            
        else
        {
            audioSrc.PlayOneShot(destroyClip);
            this.gameObject.SetActive(false);
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

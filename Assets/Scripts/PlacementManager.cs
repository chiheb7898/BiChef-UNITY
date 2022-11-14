using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{
    public ARRaycastManager raymanager;
    public GameObject PointerObj;
    private ARPlaneManager pm;


    // Start is called before the first frame update
    void Start()
    {
        raymanager = FindObjectOfType<ARRaycastManager>();
        pm = FindObjectOfType<ARPlaneManager>();
        //pm.enabled = false;
        PointerObj = this.transform.GetChild(0).gameObject;
        PointerObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        raymanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);

        if(hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if (!PointerObj.activeInHierarchy)
            {
                PointerObj.SetActive(true);
            }
        }
        
    }

    public void SetAllPlanesActive(bool value)
    {

        foreach (var plane in pm.trackables)
        {
            plane.gameObject.SetActive(value);
        }
        Destroy(pm);
        Destroy(PointerObj);
    }
}

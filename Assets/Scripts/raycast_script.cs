using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class raycast_script : MonoBehaviour
{
    public GameObject spaw_prefab;
    GameObject spawned_object;
    bool object_spawned;
    ARRaycastManager arrayman;
    List <ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        object_spawned = false;
        arrayman = GetComponent<ARRaycastManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.touchCount > 0)
        {
            if (arrayman.Raycast(Input.GetTouch(0).position,hits,TrackableType.PlaneWithinPolygon))
            {
                var hitspose = hits[0].pose;
                if(!object_spawned)
                {
                    spawned_object = Instantiate<GameObject>(spaw_prefab, hitspose.position, hitspose.rotation);
                    object_spawned = true;
                }
                else
                {
                    spawned_object.transform.position = hitspose.position;
                }

            }
        }
    }
}

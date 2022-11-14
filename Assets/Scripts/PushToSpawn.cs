using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PushToSpawn : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    private GameObject createdObject;
    private GameObject[] fruits;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    void Start()
    {
        fruits = IngredCarrier.ingred;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    public void ARPlaceObject(GameObject obj)
    {
        int fruitIndex = Random.Range(0, fruits.Length);
        obj = fruits[fruitIndex];

        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }

        if (createdObject == null && placementPoseIsValid)
        {
            createdObject = Instantiate(obj, PlacementPose.position, PlacementPose.rotation);
        }

    }
}

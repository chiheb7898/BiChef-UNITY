using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class raycast_script2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject arPrefab;
    // Reference to an instance of the object that will be moved.
    private GameObject arInstance;
    // Reference to Raycast Manager used to make raycasts to detect surfaces.
    private ARRaycastManager arRaycaster;
    // Flag if an object was placed or it should be moved
    private bool objectPlaced = false;
    /// <summary>
    /// Unity method called in before first frame.
    /// </summary>
    void Start()
    {
        // Get reference to AR Raycast Manager within this game object
        arRaycaster = GetComponent<ARRaycastManager>();
        // Create instance of our object and hide it until it won't be placed
        arInstance = Instantiate(arPrefab);
        arInstance.gameObject.SetActive(false);
    }
    /// <summary>
    /// Unity method called every frame.
    /// </summary>
    void Update()
    {
        // If instance is placed then skip update.
        if (objectPlaced)
            return;
        // Make a list of AR hits
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        // Center point of screen with 4 units of depth what will be used to make raycast
        var screenPoint = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 4);
        // Trying to find a sufrace in world.
        if (arRaycaster.Raycast(screenPoint, hits))
        {
            // If we did hit something then we should place the instance in that point in space.
            // Order hits to find closest one.
            hits.OrderBy(h => h.distance);
            var pose = hits[0].pose;
            // Activate instance and move it to position on detected surface
            arInstance.gameObject.SetActive(true);
            arInstance.transform.position = pose.position;
            arInstance.transform.up = pose.up;
        }
        else
        {
            // If we didn't hit anything than we should hide instance
            arInstance.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// Method used to disable object movement, called by Place Button.
    /// </summary>
    public void PlacingFinished()
    {
        objectPlaced = true;
    }
    /// <summary>
    /// Method used to enable object movement, called by Move Button.
    /// </summary>
    public void PlacingBegin()
    {
        objectPlaced = false;
    }
}

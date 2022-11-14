using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public PlacementManager pcm;
    public bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        pcm = FindObjectOfType<PlacementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !isSpawned)
        {
            GameObject obj = Instantiate(ObjectToSpawn, pcm.transform.position, pcm.transform.rotation);
            pcm.SetAllPlanesActive(false);
            Destroy(pcm);
            isSpawned = true;
        }
    }
}

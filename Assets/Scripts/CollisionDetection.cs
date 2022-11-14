using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Toast;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject progress;
    private Progress p;
    private void Start()
    {
        progress = GameObject.Find("Progressbar");
        p = progress.GetComponent<Progress>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basket")
        {
            Destroy(gameObject);
            p.UpdateProgress();
        }
    }
}

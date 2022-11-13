using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObjects : MonoBehaviour
{
    /*
    private float dist;
    
    private Vector3 offset;
    



    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;
    private bool correct = true;
    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    void Update()
    {
        Vector3 v3;
        if (Input.touchCount != 1)
        {
            dragging = false;
            touched = false;
            if (toDragRigidbody)
            {
                SetFreeProperties(toDragRigidbody);
            }
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (correct && touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "DropArea")
            {
                toDrag = hit.transform;
                previousPosition = toDrag.position;
             //   toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                v3 = Camera.main.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - v3.x;
                posY = Input.GetTouch(0).position.y - v3.y;
              
               // SetDraggingProperties(toDragRigidbody);

                touched = true;
             
            }
        }

        if (touched && touch.phase == TouchPhase.Moved)
        {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            float posYNow = Input.GetTouch(0).position.y - posY;
            v3 = new Vector3(posXNow, posYNow, dist);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(v3) - previousPosition;
            worldPos = new Vector3(worldPos.x, worldPos.y, 0.0f);

           // toDragRigidbody.velocity = worldPos / (Time.deltaTime * 10);
            
           // toDrag.GetComponent<Collider>().enabled = false;
            previousPosition = toDrag.position;
            Debug.Log("previous"+previousPosition);
            
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
               if (Mathf.Abs(previousPosition.x - correctform.transform.position.x) <= 0.5f &&
                    Mathf.Abs(previousPosition.y - correctform.transform.position.y) <= 0.5f)
                {
            dragging = false;
                Debug.Log("test");
               // toDrag.position = new Vector3(correctform.transform.position.x, correctform.transform.position.y, correctform.transform.position.z);
                correct = false;
               // correctplace(toDragRigidbody);
            
            else
            {
                dragging = false;
                touched = false;
                previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
                SetFreeProperties(toDragRigidbody);
            }
            
            RaycastHit hitinfo;
            Ray ray = cam.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.tag == droppingtag)
                {
                    posX = hitinfo.transform.position.x;
                    posY = hitinfo.transform.position.y;

                }
            }
            toDrag.GetComponent<Collider>().enabled = true;
            
        }

    }

    private void SetDraggingProperties(Rigidbody rb)
    {
        rb.useGravity = false;
        rb.drag = 20;
    }

    private void SetFreeProperties(Rigidbody rb)
    {
        rb.useGravity = true;
        rb.drag = 5;
    }
    private void correctplace(Rigidbody rb)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.drag = 5;
    }*/
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;

    // Update is called once per frame
    void Update()
    {

        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "DropArea")
                {
                    toDrag = hit.transform;
                   // dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, pos.z);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;
                }
            }
        }

        if (dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }
    }
}

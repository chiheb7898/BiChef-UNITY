using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class touch : MonoBehaviour
{
    public GameObject cube;
    public GameObject elment2;
    public Image element1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cube.transform.position, Time.deltaTime);
      if (Input.touchCount>0)
        {
            if(cube == getClickgameobject(out RaycastHit hit))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                cube.transform.position =touchPosition;
            }
            if (elment2 == getClickgameobject(out RaycastHit hitt))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                elment2.transform.position = touchPosition;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (cube == getClickgameobject(out RaycastHit hit))
            {
               
                element1.GetComponent<Image>().color = new Color32(255, 255, 225, 100);

                cube.transform.position = element1.transform.position;
            }
        }
    }
    GameObject getClickgameobject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit ))
            { if (!ispointeroverui()) { target = hit.collider.gameObject; } }
        return target;
    }
    private bool ispointeroverui()
    {
        PointerEventData per = new PointerEventData(EventSystem.current);
        per.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> resultats = new List<RaycastResult>();
        EventSystem.current.RaycastAll(per, resultats);
        return resultats.Count > 0;
    }
}

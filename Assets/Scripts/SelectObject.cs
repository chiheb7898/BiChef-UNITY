using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EasyUI.Toast;

public class SelectObject : MonoBehaviour
{
    public GameObject cube;
    public GameObject paricleHob;
    public AnimatedTextureUVs paricleCooking;
    public AudioSource paricleCookingSound;
    public GameObject paricleCookingfog;
    private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StopCooking();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, cube.transform.position, Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            if (cube == getClickgameobject(out RaycastHit hit))
            {
                if (isActive)
                {
                    StopCooking();
                }
                else
                {
                    StartCooking();
                }
            }
        }

    }
    GameObject getClickgameobject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
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

    public void StartCooking()
    {
        paricleHob.SetActive(true);
        paricleCookingSound.Play();
        paricleCooking.runScript = true;
        paricleCookingfog.SetActive(true);
        isActive = true;
        Toast.Show(" Hob is turned On!");
    }
    public void StopCooking()
    {
        paricleHob.SetActive(false);
        paricleCooking.runScript = false;
        paricleCookingSound.Stop();
        paricleCookingfog.SetActive(false);
        isActive = false;
        Toast.Show(" Hob is turned Off!");
    }

}

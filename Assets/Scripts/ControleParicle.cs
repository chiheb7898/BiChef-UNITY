using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleParicle : MonoBehaviour
{
    [SerializeField]
    private GameObject paricle;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        paricle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setParticleActive(GameObject p)
    {
        if (!isActive)
        {
            p.SetActive(true);
            isActive = true;
        }
    }
    public void setParticleNotActive(GameObject p)
    {
        if (isActive)
        {
            p.SetActive(false);
            isActive = false;
        }
    }
}

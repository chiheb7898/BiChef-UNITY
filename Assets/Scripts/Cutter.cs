using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    Vector3 randomAngle;
    public GameObject knife;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Slice" && knife.GetComponent<Knife>().isCutting)
        {
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            col.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.left * 0.001f, ForceMode.Impulse);
            randomAngle = new Vector3(Random.Range(-0.001f, -0.002f), Random.Range(0.002f, 0.003f), Random.Range(-0.005f, 0.005f));
            col.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(650,1500), ForceMode.Impulse);
            knife.GetComponent<Knife>().SetCuttingState(true);
            GameSystem.System.LEVEL.OnVegetableCut();

            Destroy(col.gameObject, 4f);
            Destroy(col.gameObject.transform.parent.gameObject, 4f);
        }
    }
}

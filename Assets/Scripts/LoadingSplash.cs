using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSplash : MonoBehaviour
{
    float time, second;
    [SerializeField]
    public Image FillImage;
    // Start is called before the first frame update
    void Start()
    {
        second = 3;
        Invoke("LoadGame", 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 3)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}

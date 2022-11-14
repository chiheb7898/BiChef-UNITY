using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {
            OnClick(param);
        });
    }
}

public class menu : MonoBehaviour
{
    [Serializable]
    public struct Menu
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        public GameObject[] ingred;
    }

    [SerializeField] Menu[] allMenus;

    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;
        int N = allMenus.Length;
        for(int i =0;i<N;i++)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = allMenus[i].Icon;
            g.transform.GetChild(1).GetComponent<Text>().text = allMenus[i].Name;
            g.transform.GetChild(2).GetComponent<Text>().text = allMenus[i].Description;
            g.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }
        Destroy(buttonTemplate);


    }
    void ItemClicked(int itemIndex)
    {
        
        Debug.Log("------------item " + itemIndex + " clicked---------------");
        Debug.Log("name " + allMenus[itemIndex].Name);
        Debug.Log("desc " + allMenus[itemIndex].Description);
        IngredCarrier.ingred = allMenus[itemIndex].ingred;
        SceneManager.LoadScene("SampleScene");
    }


}

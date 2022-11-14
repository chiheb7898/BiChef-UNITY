using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        //StartCoroutine(LoadAsynchronously(sceneIndex).ToString);
    }

     IEnumerable LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}

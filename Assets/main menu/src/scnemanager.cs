using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChanger : MonoBehaviour
{

    public string sceneName;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(Timer(sceneName));
    }

    IEnumerator Timer(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

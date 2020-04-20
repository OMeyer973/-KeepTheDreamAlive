using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLaunch = "Menu";
    public bool changeOnAwake = false;

    private void Awake()
    {
        if (changeOnAwake)
        {
            GoToScene();
        }
    }

    void GoToScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLaunch);
    }
}

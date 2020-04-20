using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public GameObject SkipIntroUI;
    void Update()
    {
        if (Input.anyKey)
        {
            ShowSkipUI();
        }
    }
    void ShowSkipUI()
    {
        SkipIntroUI.SetActive(true);
    }

    public void Skip()
    {
        if (Game.Instance == null) Debug.Log("Warning : game instance is null");
        Game.Instance.GoToMenu();
    }
   
}

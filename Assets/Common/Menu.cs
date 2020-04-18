using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        Game.Instance.LaunchCurrentLevel();
    }

    public void ReturnToMenu()
    {
        Game.Instance.GoToMenu();
    }

    public void Settings()
    {
        Game.Instance.GoToSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

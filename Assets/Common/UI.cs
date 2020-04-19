using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else{
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public GameObject SettingsScreen;
    public GameObject MirrorSpeechOverlay;
    public GameObject PauseScreen;
    public GameObject LevelVictoryScreen;

    private void Start()
    {
        /*
        SettingsScreen = transform.Find("SettingsScreen").gameObject;
        MirrorSpeechOverlay = transform.Find("MirrorSpeechOverlay").gameObject;
        PauseScreen = transform.Find("PauseScreen").gameObject;
        LevelVictoryScreen = transform.Find("LevelVictoryScreen").gameObject;
        */
    }

    public void HideAll()
    {
        SettingsScreen.SetActive(false);
        MirrorSpeechOverlay.SetActive(false);
        PauseScreen.SetActive(false);
        LevelVictoryScreen.SetActive(false);
    }

    // display the UI for a level
    public void LaunchLevel()
    {
        SettingsScreen.SetActive(false);
        MirrorSpeechOverlay.SetActive(true);
        PauseScreen.SetActive(false);
        LevelVictoryScreen.SetActive(false);
    }

    public void UpdateMirrorUI (int hitPointsLeft)
    {
        // todo
    }

    public void ShowPauseScreen()
    {
        PauseScreen.SetActive(true);
    }

    public void HidePauseScreen()
    {
        PauseScreen.SetActive(false);
    }

    // display the UI when a level is won
    public void ShowLevelVictoryScreen ()
    {
        LevelVictoryScreen.SetActive(true);
    }

    public void ShowSettingsScreen()
    {
        SettingsScreen.SetActive(true);
    }

    public void HideSettingsScreen()
    {
        SettingsScreen.SetActive(false);
    }

}

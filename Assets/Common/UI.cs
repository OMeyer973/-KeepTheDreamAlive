using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    public SelfWritingText MirrorTextWriter;

    [Header("UI Layers (this guy's children)")]
    public GameObject SettingsScreen;
    public GameObject MirrorSpeechOverlay;
    public GameObject PauseScreen;
    public GameObject LevelVictoryScreen;

    public string[] levelAdvices =
        {
        "Welcome to Your new mirror delivery job young lad. Your task is to bring me up this tower to the princess who ordered me",
        "cc cv"
    };
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else{
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }       

    private void Start()
    {
        if (levelAdvices.Length < Game.Instance.nbLevels)
        {
            Debug.LogWarning("Warning : there are less level advices than levels, will encounter array overflow at some point");
        }
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
    public void LaunchLevel(int id)
    {
        SettingsScreen.SetActive(false);
        MirrorSpeechOverlay.SetActive(true);
        PauseScreen.SetActive(false);
        LevelVictoryScreen.SetActive(false);
        if (id <= Game.Instance.nbLevels)
        {
            MirrorTextWriter.TypeText(levelAdvices[id]);
        }
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

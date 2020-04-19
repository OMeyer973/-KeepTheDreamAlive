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

    public List<string> levelAdvices;
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

        if (levelAdvices.Count < Game.Instance.nbLevels)
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
        MirrorTextWriter.TypeText("Hey be careful with these sharp angles ! if you dou that again yo''l break me !", .01f);
        // todo msg
        // todo graphics
        // todo sound
    }

    public void showLostMessage(LoseCondition loseCondition)
    {
        switch(loseCondition)
        {
            case LoseCondition.FellInHole:
                MirrorTextWriter.TypeText("Well you won't be able to deliver me if stay in that hole...", .01f);
                break;
            case LoseCondition.HitWall:
                MirrorTextWriter.TypeText("Ouch broke me against that wall ! Be more careful next time !", .01f);
                break;
        }
        // todo sound
        // todo animate mirror portrait
    }

    public void ShowPauseScreen()
    {
        PauseScreen.SetActive(true);
        // todo sound
    }

    public void HidePauseScreen()
    {
        PauseScreen.SetActive(false);
        // todo sound
    }

    // display the UI when a level is won
    public void ShowLevelVictoryScreen ()
    {
        LevelVictoryScreen.SetActive(true);
        // todo sound
    }

    public void ShowSettingsScreen()
    {
        SettingsScreen.SetActive(true);
        // todo sound
    }

    public void HideSettingsScreen()
    {
        SettingsScreen.SetActive(false);
        // todo sound
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    public SelfWritingText MirrorTextWriter;

    [Header("UI Layers (this guy's children)")]
    public GameObject SettingsScreen;
    public GameObject InGameUI;
    public Text InGameLevelNameText;
    public Text InGameTimerText;
    public List<Image> mirrorImages;
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
        InGameUI = transform.Find("InGameUI").gameObject;
        PauseScreen = transform.Find("PauseScreen").gameObject;
        LevelVictoryScreen = transform.Find("LevelVictoryScreen").gameObject;
        */
    }

    public void HideAll()
    {
        SettingsScreen.SetActive(false);
        InGameUI.SetActive(false);
        PauseScreen.SetActive(false);
        LevelVictoryScreen.SetActive(false);
    }

    // display the UI for a level
    public void LaunchLevel(int id)
    {
        SettingsScreen.SetActive(false);
        InGameUI.SetActive(true);
        PauseScreen.SetActive(false);
        LevelVictoryScreen.SetActive(false);

        InGameLevelNameText.text = "Room " + (id + 1);
        setMirrorImage(Game.Instance.mirrorMaxHp);
        WriteLevelAdvice(id);
    }

    public void UpdateTimerDisplay(string currentTimeString)
    {
        InGameTimerText.text = currentTimeString;
    }

    public void WriteLevelAdvice (int id)
    {
        if (id >= Game.Instance.nbLevels)
        {
            Debug.LogError("trying to ontput a msg for a non existing level");
            return;
        }
        if (id >= levelAdvices.Count)
        {
            MirrorTextWriter.TypeText("This is the " + id + "th level, you do't need anymore advice now !");
            Debug.Log("no advice provided for level " + id + " fallback on generic message");
        }
        else
        {
            MirrorTextWriter.TypeText(levelAdvices[id]);
        }

    }

    public void UpdateMirrorUI (int hitPointsLeft)
    {
        if (hitPointsLeft == 2)
        {
            MirrorTextWriter.TypeText("Hey Be careful, you scratched me !", .005f);
        }
        if (hitPointsLeft == 1)
        {
            MirrorTextWriter.TypeText("Ouch ! I'm about to break !!", .005f);
        }
        if (hitPointsLeft == 0)
        {
            MirrorTextWriter.TypeText("...", 0);
        }

        setMirrorImage(hitPointsLeft);

        // todo graphics
        // todo sound
    }

    private void setMirrorImage (int hitPointsLeft)
    {
        for (int i = 0; i < mirrorImages.Count; i++)
        {
            if (i == hitPointsLeft)
            { // show image
                mirrorImages[i].color = new Color(1, 1, 1, 1);
            }
            else
            {// hide image
                mirrorImages[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
    public void showLostMessage(LoseCondition loseCondition)
    {
        switch(loseCondition)
        {
            case LoseCondition.FellInHole:
                MirrorTextWriter.TypeText("You fell into a hole", 0);
                break;
            case LoseCondition.HitWall:
                MirrorTextWriter.TypeText("7 years of bad luck", 0);
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

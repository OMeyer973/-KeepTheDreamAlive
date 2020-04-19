using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("for Menu scene & victory scene use only")]
    public Text timesText;

    private void Start()
    {
        if (timesText == null)
        {
            Debug.LogWarning("make sure to assign text fields for timesText");
        }

        updateMenuTimeTexts();
    }

    public void Play()
    {
        Game.Instance.LaunchCurrentLevel();
    }

    public void ReturnToMenu()
    {
        Game.Instance.GoToMenu();
    }

    public void updateMenuTimeTexts()
    {
        string bestTimeText = Timer.Instance.getBestTimeString();
        string lastCompleteTimeText = Timer.Instance.getLastCompleteTimeString();
        timesText.text = "Best time:\n" + bestTimeText + "\nYour time:\n" + lastCompleteTimeText;
    }

    public void Settings()
    {
        Game.Instance.GoToSettings();
    }

    public void ResetGame()
    {
        Game.Instance.ResetGame();
    }
}

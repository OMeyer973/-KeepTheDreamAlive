using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LoseCondition {
    HitWall,
    FellInHole
}

public enum GameState
{
    InAMenu,
    PlayingALevel,
    LostLevelAndAwaitingReload
}

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public int nbLevels = 1;
    private int currLevelID;

    public int mirrorMaxHp = 3;

    public float timeBetweenLevelLostAndReset = 3;
    public GameState gameState = GameState.InAMenu;

    private GameState prevGameState = GameState.InAMenu;

    void Awake()
    {
        if (Instance == null) { 
            Instance = this; 
        } else { 
            Debug.Log("Warning: multiple " + this + " in scene!"); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GoToMenu();
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void GoToSettings()
    {
        UI.Instance.ShowSettingsScreen();
    }

    public void CloseSettings()
    {
        UI.Instance.HideSettingsScreen();
    }

    public void PauseGame()
    {
        UI.Instance.ShowPauseScreen();
        prevGameState = gameState;
        gameState = GameState.InAMenu;
        //todo stop time
    }

    public void UnpauseGame()
    {
        UI.Instance.HidePauseScreen();
        gameState = prevGameState;
        //todo stop time
    }

    public void LoseLevel(LoseCondition loseCondition)
    {
        if (gameState == GameState.LostLevelAndAwaitingReload) return; // we're allready in a lose loop
        
        UI.Instance.showLostMessage(loseCondition);
        gameState = GameState.LostLevelAndAwaitingReload;
        // show death msg
        StartCoroutine(WaitAndReloadLevel());
    }

    IEnumerator WaitAndReloadLevel()
    {
        yield return new WaitForSeconds(timeBetweenLevelLostAndReset);
        gameState = GameState.PlayingALevel;
        LaunchCurrentLevel();
}

    // show the level win card  (w ui to go to menu, go to next level...)
    // called when the player has reached the end of a level
    public void FinishLevel()
    {
            gameState = GameState.InAMenu;
        UI.Instance.ShowLevelVictoryScreen();
    }

    // load the current level (ie the first level at the first launch)
    public void LaunchCurrentLevel()
    {
        LaunchLevel(currLevelID);
    }

    // called when level win card nextLevel btn has been pressed    
    public void GoToNextLevel()
    {
        currLevelID++;
        if (currLevelID >= nbLevels)
        {
            UI.Instance.HideAll();
            LoadScene("VictoryScene");
        } else
        {
            LaunchLevel(currLevelID);
        }
    }

    // go back to the main menu
    public void GoToMenu()
    {
        LoadScene("Menu");
        UI.Instance.HideAll();
    }

    public void ResetGame()
    {
        currLevelID = 0;
        GoToMenu();
    }


    void LoadScene(string sceneName)
    {
        Debug.Log("loading " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    void LaunchLevel (int id)
    {
        gameState = GameState.PlayingALevel;
        UI.Instance.LaunchLevel(id);
        LoadScene("Level_" + id);
    }
}

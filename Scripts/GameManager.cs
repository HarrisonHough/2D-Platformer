using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum InputMode { PC, Mobile, Controller };

public enum GameState { InMenu, InGame, Paused, Finished }

public struct PlayerStats
{
    public float time;
    public int deathCount;
    public int coins;
}
public class GameManager : GenericSingleton<GameManager> {

    private SceneVariables sceneVariables;
    public SceneVariables SceneVariables { get { return sceneVariables; } }

    private bool isInputFlipped = false;
    public bool IsInputFlipped { get { return isInputFlipped; } }

    private InputMode inputMode = InputMode.PC;
    public InputMode InputMode { get { return inputMode; } }


    private AudioController audioController;
    public AudioController AudioController { get { return audioController; } }

    private GameState gameState = GameState.InMenu;
    public GameState CurrentGameState { get { return gameState; } }

    private int playerDeathCount = 0;
    public int PlayerDeathCount { get { return playerDeathCount; } }

    private TimeManager timeManager;
    public TimeManager TimeManager { get { return timeManager; } }

    private PlayerStats playerStats;

    private bool checkpointsEnabled = false;
    public bool CheckpointsEnabled { get { return checkpointsEnabled; } }

    private int currentCheckpointIndex;
    public int CurrentCheckpointIndex { get { return currentCheckpointIndex; } }

    

    public override void Awake()
    {
        base.Awake();
        timeManager = GetComponent<TimeManager>();
        audioController = GetComponent<AudioController>();
        gameState = GameState.InMenu;
    }

    // Use this for initialization
    void Start () {

        if (Application.isMobilePlatform)
        {
            inputMode = InputMode.Mobile;
        }
	}

 

    public void OnGameSceneLoad()
    {
        if (!sceneVariables)
            sceneVariables = FindObjectOfType<SceneVariables>();
        if (!checkpointsEnabled)
            sceneVariables.CheckpointsParent.SetActive(false);
        else
            sceneVariables.PlayerObject.transform.position = sceneVariables.CheckpointArray[currentCheckpointIndex].transform.position;

        //resetIsFlipped
        isInputFlipped = false;
        //Reset coin count
        playerStats.coins = 0;

        //TODO move somewhere better?
        gameState = GameState.InGame;
    }

    public void StartNewGame()
    {
        //reset checkpoint index
        currentCheckpointIndex = 0;
        //reset death count
        playerDeathCount = 0;
        //reset timer
        timeManager.SetStartTime();
    }

    public void UpdateCheckpointIndex(int index)
    {
        currentCheckpointIndex = index;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CoinCollected()
    {
        playerStats.coins++;
        //audioController.PlayItemCollectSound();
        sceneVariables.LiveUI.UpdateCoinCountText(playerStats.coins);
    }

    public void PlayerDeath()
    {
        AudioController.PlayDeathSound();
        sceneVariables.UIControl.ToggleRestartButton(true);
        sceneVariables.UIControl.UIHints.DisplayRandomDeathPhrase();
        playerDeathCount++;
        sceneVariables.LiveUI.UpdateDeathCountText(playerDeathCount);
    }

    public void GameFinished()
    {
        gameState = GameState.InMenu;

        //set end time
        timeManager.SetEndTime();
        SceneVariables.LiveUI.HideLiveUI();

        //update player stats
        playerStats.time = timeManager.GetFinalTime();
        playerStats.deathCount = playerDeathCount;

        AudioController.PlayGameCompleteSound();

        //hide/disable movement controls
        sceneVariables.UIControl.ToggleMobileControls(false);
        sceneVariables.UIControl.ToggleRestartButton(false);
        SceneVariables.PlayerMovement.StopMovement();

        //update player stats
        sceneVariables.UIControl.UpdateFinalScoreAndDeaths(playerStats.time, playerStats.deathCount);

        //show game complete UI
        sceneVariables.UIControl.ToggleScorePanel(true);
        

        


    }

    public void FlipInput()
    {
        isInputFlipped = !isInputFlipped;
        sceneVariables.PlayerMovement.FlipMoveDirection();
    }

    public void ToggleCheckpoints()
    {
        checkpointsEnabled = !checkpointsEnabled;
    }
}

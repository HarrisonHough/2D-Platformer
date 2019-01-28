using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour {

    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject scorePanel;
    [SerializeField]
    private GameObject mobileButtonsPanel;
    [SerializeField]
    private GameObject mobileButtonsFlippedPanel;
    [SerializeField]
    private UIHints uiHints;
    public UIHints UIHints { get { return uiHints; } }

    [SerializeField]
    private Text finalTimeText;
    [SerializeField]
    private Text finalDeathCountText;
	// Use this for initialization
	void Start () {
        
        ToggleRestartButton(false);
        if (uiHints == null)
            uiHints = FindObjectOfType<UIHints>();
        if (Application.isMobilePlatform)
            ToggleMobileControls(true);

        //TODO move to more suitable class
        GameManager.Instance.AudioController.StartGameMusic();
	}

    public void HomeButtonPress()
    {
        GameManager.Instance.LoadScene(0);
    }

    public void LoadSceneAndRestart(int sceneIndex)
    {
        GameManager.Instance.StartNewGame();
        GameManager.Instance.LoadScene(sceneIndex);
    }
    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        GameManager.Instance.LoadScene(sceneIndex);
    }

    public void ToggleMobileControls(bool active)
    {
        mobileButtonsPanel.SetActive(active);
    }

    public void UpdateMobileControls()
    {
        if (GameManager.Instance.InputMode == InputMode.PC)
            return;
        if (GameManager.Instance.IsInputFlipped)
        {
            mobileButtonsPanel.SetActive(false);
            mobileButtonsFlippedPanel.SetActive(true);
        }
        else
        {
            mobileButtonsPanel.SetActive(true);
            mobileButtonsFlippedPanel.SetActive(false);
        }
    }

    public void ToggleRestartButton(bool active)
    {
        restartButton.SetActive(active);
    }

    public void ToggleScorePanel(bool active)
    {
        scorePanel.SetActive(active);
    }

    public void UpdateFinalScoreAndDeaths(float time, int deaths)
    {
        finalTimeText.text = "Time: " + Utilities.FormatTime(time);
        finalDeathCountText.text = "Deaths: " + deaths;
    }
}

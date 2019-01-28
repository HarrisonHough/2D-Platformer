using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject CodesPanel;

    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;

    
    [SerializeField]
    private InputField codeInputField;

    [SerializeField]
    private Text codeLogMessageText;


	// Use this for initialization
	void Start () {
        //TODO move somewhere that makes sense. Scene class ?
        GameManager.Instance.AudioController.StartMenuMusic();
    }

    void DisableAllPanels()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(false);
        CodesPanel.SetActive(false);
        //clear each time you hide
        SetCodeLogMessageText("");
    }

    public void PlayButtonPress()
    {
        GameManager.Instance.AudioController.PlayUIClickSound();
        GameManager.Instance.LoadScene(1);
        GameManager.Instance.StartNewGame();
    }

    public void SettingsButtonPress()
    {
        GameManager.Instance.AudioController.PlayUIClickSound();
        UpdateAudioSliders();
        DisableAllPanels();
        settingsPanel.SetActive(true);
    }

    public void CodesButtonPress()
    {
        GameManager.Instance.AudioController.PlayUIClickSound();
        DisableAllPanels();
        CodesPanel.SetActive(true);

    }

    public void SendCodeButtonPress()
    {
        TryCode(codeInputField.text);
    }

    public void BackToMainPanel()
    {
        GameManager.Instance.AudioController.PlayUIClickSound();
        DisableAllPanels();
        mainPanel.SetActive(true);
    }

    public void UpdateAudioSliders()
    {
        masterSlider.value = GameManager.Instance.AudioController.GetMasterVolume();
        musicSlider.value = GameManager.Instance.AudioController.GetMusicVolume();
        sfxSlider.value = GameManager.Instance.AudioController.GetSFXVolume();
    }

    public void OnMasterSliderChange(float value)
    {
        Debug.Log("Value set to " + value);
        GameManager.Instance.AudioController.SetMasterVolume(value);
    }

    public void OnMusicSliderChange(float value)
    {
        
        GameManager.Instance.AudioController.SetMusicVolume(value);
    }

    public void OnSFXSliderChange(float value)
    {
        GameManager.Instance.AudioController.SetSFXVolume(value);
    }

    private void SetCodeLogMessageText(string message)
    {
        codeLogMessageText.text = "";
        codeLogMessageText.text = message;
    }

    public void TryCode(string codeText)
    {
        codeText = codeText.ToUpper();
        switch (codeText)
        {
            case "CHECKMEOUT":
                GameManager.Instance.ToggleCheckpoints();
                if(GameManager.Instance.CheckpointsEnabled)
                    SetCodeLogMessageText("Checkpoints Activated");
                else
                    SetCodeLogMessageText("Checkpoints Deactivated");
                GameManager.Instance.AudioController.PlayGameCompleteSound();
                break;
            default:

                break;
        }
    }

}

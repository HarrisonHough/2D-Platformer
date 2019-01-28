using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHints : MonoBehaviour {

    [SerializeField]
    private Text hintText;
    [SerializeField]
    private CanvasGroup canvasGroup;
    private string textToDisplay;

    private float time = 0f;
    private float fadeTime = 1f;
    public enum FadeState {None, FadeIn, FadeOut };
    private FadeState fadeState;

    private bool isTimerOn = false;
    private float messageDisplayTime = 3f;
    private float nextTextClearTime = 0;

    [SerializeField]
    private string[] deathPhrases;
    [SerializeField]
    private string welcomeMessage;

	// Use this for initialization
	void Start () {
        SetHintText(welcomeMessage);
	}

    public void DisplayRandomDeathPhrase()
    {

        ClearText();
        time = 0;
        fadeState = FadeState.FadeIn;
        nextTextClearTime = Time.time + messageDisplayTime + (fadeTime);
        isTimerOn = true;
        textToDisplay += deathPhrases[ Random.Range(0,deathPhrases.Length)];
        hintText.text = textToDisplay;
    }

    public void SetHintText(string newText)
    {
        ClearText();
        time = 0;
        fadeState = FadeState.FadeIn;
        nextTextClearTime = Time.time + messageDisplayTime + (fadeTime);
        isTimerOn = true;
        textToDisplay += newText;
        hintText.text = textToDisplay;
        
    }

    public void ClearText()
    {
        hintText.text = textToDisplay = "";
    }

    private void StartFadeOut()
    {
        time = 0;
        fadeState = FadeState.FadeOut;
        isTimerOn = false;
        Debug.Log("Start Fade Out");
    }
	// Update is called once per frame
	void Update () {

        if (nextTextClearTime < Time.time && isTimerOn)
        {
            StartFadeOut();
        }
        Fade();
	}

    void Fade()
    {
        switch (fadeState)
        {
            case FadeState.FadeIn:
                time += Time.deltaTime / fadeTime;
                canvasGroup.alpha = Mathf.Lerp(0,1,time);

                if (time > 1)
                {
                    fadeState = FadeState.None;
                }
                break;
            case FadeState.FadeOut:
                time += Time.deltaTime / fadeTime;
                //Debug.Log("time = " + time);
                canvasGroup.alpha = Mathf.Lerp(1, 0, time);
                //Debug.Log("fading out");
                if (time > 1)
                {
                    fadeState = FadeState.None;
                    ClearText();
                    //Debug.Log("fading out finished");
                }
                break;
            default:

                break;
        }

        
    }

  
}

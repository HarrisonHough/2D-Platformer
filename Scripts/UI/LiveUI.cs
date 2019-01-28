using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour {

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text deathCountText;
    [SerializeField]
    private Text coinCountText;

    private void Start()
    {
        UpdateDeathCountText(GameManager.Instance.PlayerDeathCount);
    }

    private void Update()
    {
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        timerText.text = Utilities.FormatTime(Time.time - GameManager.Instance.TimeManager.StartTime);
    }

    public void UpdateDeathCountText(int numberOfDeaths)
    {
        deathCountText.text = "Deaths:" + numberOfDeaths;
    }

    public void UpdateCoinCountText(int numberOfCoins)
    {
        coinCountText.text = "Coins:" + numberOfCoins;
    }

    public void HideLiveUI()
    {
        timerText.enabled = false;
        deathCountText.enabled = false;
        coinCountText.enabled = false;
    }
}

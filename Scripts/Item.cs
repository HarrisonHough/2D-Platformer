using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Controls, Death, Coin, Speed, Colours }

public class Item : MonoBehaviour {

    public ItemType type = ItemType.Controls;

	// Use this for initialization
	void Start () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerItemEffect();
            gameObject.SetActive(false);
        }
    }

    private void TriggerItemEffect()
    {
        GameManager.Instance.AudioController.PlayItemCollectSound();
        switch (type)
        {
            case ItemType.Controls:

                //flip pc input buttons
                GameManager.Instance.FlipInput();
                //flip UI controls
                GameManager.Instance.SceneVariables.UIControl.UpdateMobileControls();
                GameManager.Instance.SceneVariables.UIControl.UIHints.SetHintText("Left is right?");
                break;
            case ItemType.Coin:
                GameManager.Instance.CoinCollected();

                break;
            case ItemType.Death:
                //animation/effect and death

                break;
            case ItemType.Speed:
                //adjust movement speed;

                break;
            case ItemType.Colours:
                //Swap colours of danger and safe

                break;
            default:
                break;
        }
    }


}

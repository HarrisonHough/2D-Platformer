using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour {

    

    [SerializeField]
    private PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
        

        
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.CurrentGameState != GameState.InGame)
            return;
        if (GameManager.Instance.InputMode == InputMode.PC)
        {
            if (!GameManager.Instance.IsInputFlipped)
                PCInput();
            else
                PCInputFlipped();
        }
	}

    void PCInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerMovement.ButtonLeftPress();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerMovement.ButtonLeftRelease();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerMovement.ButtonRightPress();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerMovement.ButtonRightRelease();
        }
        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.JumpPressDown();
        }
        if (Input.GetButtonUp("Jump"))
        {
            playerMovement.JumpRelease();
        }
    }

    void PCInputFlipped()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerMovement.ButtonLeftPress();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerMovement.ButtonLeftRelease();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerMovement.ButtonRightPress();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerMovement.ButtonRightRelease();
        }
        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.JumpPressDown();
        }
        if (Input.GetButtonUp("Jump"))
        {
            playerMovement.JumpRelease();
        }
    }

    public void JumpPress()
    {
        playerMovement.JumpPressDown();
    }

    public void JumpRelease()
    {
        playerMovement.JumpRelease();
    }

}

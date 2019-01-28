using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Danger")
        {
            Death();
        }
    }

    void Death()
    {
        GameManager.Instance.PlayerDeath();
        Debug.Log("Player Died");
        gameObject.SetActive(false);
    }
}

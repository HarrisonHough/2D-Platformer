using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private int checkpointIndex;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.UpdateCheckpointIndex(checkpointIndex);
            GameManager.Instance.AudioController.PlayItemCollectSound();
        }
    }
}

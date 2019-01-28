using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour {

    [SerializeField]
    private bool hideOnCollision;
	// Use this for initialization
	void Start () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You reached the finish!");
        GameManager.Instance.GameFinished();

        if (hideOnCollision)
            gameObject.SetActive(false);
    }


}

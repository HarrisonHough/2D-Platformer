using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour {

    public UnityEvent triggerEvent;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            TriggerActivated();
        }
    }

    private void  TriggerActivated()
    {
        Debug.Log("trigger entered");

        //play animation

        //play sound

        //trigger event
        triggerEvent.Invoke();
    }
}

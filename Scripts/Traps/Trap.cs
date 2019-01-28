using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void DisableObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

    public void EnableObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(false);
    }

}

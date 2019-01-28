using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScoreMenu : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}

    public void LoadScene(int index)
    {
        GameManager.Instance.LoadScene(index);
    }
}

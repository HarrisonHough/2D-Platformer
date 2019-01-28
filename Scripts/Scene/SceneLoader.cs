using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GameManager.Instance.OnGameSceneLoad();        
    }
}

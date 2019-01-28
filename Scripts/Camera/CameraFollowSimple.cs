using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour {

    [SerializeField]
    private GameObject targetToFollow;

    [SerializeField]
    private bool lockYPosition;

    [SerializeField]
    private float xOffset;
    private float yOffset;

    private Vector3 targetPosition;
    
	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        
        if (!lockYPosition)
        {
            targetPosition.y = targetToFollow.transform.position.y;
        }

        targetPosition.x = targetToFollow.transform.position.x + xOffset;
        transform.position = targetPosition;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = velocity;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSprite : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool hideOnStart = true;
	// Use this for initialization
	void Start () {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (hideOnStart)
        {
            spriteRenderer.enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ShowSprite();
        }
    }

    private void ShowSprite()
    {
        spriteRenderer.enabled = true;
    }
}

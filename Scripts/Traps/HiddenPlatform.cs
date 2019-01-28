using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlatform : MonoBehaviour {

    [SerializeField]
    private Trigger trigger;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    BoxCollider2D collider2D;

	// Use this for initialization
	void Start () {
        if(spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if(trigger == null)
            trigger = GetComponent<Trigger>();

        collider2D = GetComponent<BoxCollider2D>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triggered!");
       
        trigger.TriggerAction();
    }

    public void SetIsTrigger(bool active)
    {
        collider2D.isTrigger = active;
    }

    public void EnableMeshRenderer()
    {
        spriteRenderer.enabled = true;
    }
    
}

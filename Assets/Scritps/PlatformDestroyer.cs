using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    public bool touchy;

    public GameObject platformDestructionPoint;
	// Use this for initialization
	void Start () {
        myCollider = GetComponent<Collider2D>();
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");

	}
	
	// Update is called once per frame
	void Update () {
        touchy = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        if (touchy)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}

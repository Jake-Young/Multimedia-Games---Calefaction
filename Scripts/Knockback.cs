using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float explosionStrength = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 forceVec = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.normalized.x * explosionStrength, -collision.GetComponent<Rigidbody2D>().velocity.normalized.y * explosionStrength);
        collision.GetComponent<Rigidbody2D>().AddForce(forceVec, ForceMode2D.Force);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

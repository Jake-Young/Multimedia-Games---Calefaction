using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public AudioClip MissileExplodingSound; // sound that plays when missile explodes
    private AudioSource MissileExploding;

    private void Start()
    {
        Invoke("DestoryExplosion", 0.50f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player") //(or crates?)
        {
            Vector2 target = collider.gameObject.transform.position;
            Vector2 explosionposition = gameObject.transform.position;
            Vector2 direction = 500f * (target - explosionposition);
            //force of the explosion

            collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
            
        }

    }

    private void DestoryExplosion()
    {
        Destroy(gameObject);
    }
}

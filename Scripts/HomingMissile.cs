using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    private Animator missile_Animator; // animator for the missile
    public Transform target; //the target of the missile (the player)
    public float speed;  //speed of missile
    public float rotateSpeed; //speed the missile turns around to the target
    public bool SoundClipPlayable; //Bool to see if the sound clip has played

    public AudioClip MissileTrackingSound;// sound that plays when player is warm
    private AudioSource MissileTracking;

    public AudioClip MissileNotTrackingSound; // sound the plays when player turns cold
    private AudioSource MissileNotTracking;

    public AudioClip MissileGettingTargetSound; // sound that plays when missile spawns
    private AudioSource MissileGettingTarget;

    public GameObject explosion; //the explosion




    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        MissileTracking = GetComponent<AudioSource>();
        MissileNotTracking = GetComponent<AudioSource>();
        MissileGettingTarget = GetComponent<AudioSource>();
        SoundClipPlayable = true;
        missile_Animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeAnimation();
        IsTargetWarm();
        Invoke("PlayGetTargetSound", 2);
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosioneffect, transform.position, transform.rotation);
        if (collision.tag == "Player" || collision.tag == "Terrain")
        {
            //transform.position = new Vector3(StartPosition_X, StartPosition_Y, 0);
            //transform.rotation = new Quaternion(StartRotation_X, StartRotation_Y, 0, 0);
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            gameObject.SetActive(false);
            Invoke("DestoryMissile", 2.0f);
            if (collision.tag == "Player")
            {
                PlatformerCharacter2D.IsAlive = false;
            }

        }
        


    }

    //void OnCollisionEnter2D(Collision2D _other)
    //{
    //    if (_other.collider.gameObject.name == "Bouncy object")
    //    {
    //        _other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
    //    }
    //}

    private void IsTargetWarm()
    {
        if (HotAndCold.instance.IsWarm() == true)
        {
            // direction the missile needs to face to point towards the player
            Vector2 direction = (Vector2)target.position - rb.position;
            //ensures the vector has a magnitude of 1
            direction.Normalize();
            // The cross product between the missile and the player (used to find out what way the missile needs to turn to in order to point to the player) 
            float RotateAmount = Vector3.Cross(direction, transform.up).z;

            //sets the speed at which the missile points towards the player
            rb.angularVelocity = -RotateAmount * rotateSpeed;
        }
    }

    private void ChangeAnimation()
    {
        if (HotAndCold.instance.IsWarm() == true)
        {
            missile_Animator.SetBool("IsMissileTracking", true);
            if (SoundClipPlayable == true)
            {
                MissileTracking.Play();
                SoundClipPlayable = false;
                Invoke("AllowChangeTargetClipToPlay", 1);
            }
        }
        else
        {
            missile_Animator.SetBool("IsMissileTracking", false);
            if (SoundClipPlayable == true)
            {
                MissileNotTracking.Play();
                SoundClipPlayable = false;
                Invoke("AllowChangeTargetClipToPlay", 1);
            }
        }
    }

    private void PlayGetTargetSound() //Plays sound clip when the missile is spawned
    {
        //MissileGettingTarget.Play();
    }

    private void AllowChangeTargetClipToPlay()
    {

    }

    private void DestoryMissile()
    {
        Destroy(gameObject);
    }

    //private void AddForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    //{
    //    var dir = (body.transform.position - explosionPosition);
    //    float wearoff = 1 - (dir.magnitude / explosionRadius);
    //    body.AddForce(dir.normalized * explosionForce * wearoff);
    //}

    //private void explode()
    //{
    //    var all_rigidbodies = FindObjectsOfType<Rigidbody2D>();

    //    foreach (var r in all_rigidbodies)
    //    {
    //        if (Vector2.Distance(r.transform.position, transform.position) < 6 && r.tag == "Player")
    //        {
    //            var px = r.transform.position.x - transform.position.x;
    //            var py = r.transform.position.y - transform.position.y;



    //            r.AddForce((new Vector2(px, py)* 200), ForceMode2D.Force);
    //                //ForceMode2D.Force);
    //        }
    //    }

    //}
}


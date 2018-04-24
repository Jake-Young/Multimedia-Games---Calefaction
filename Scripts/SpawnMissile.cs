using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour {

    public Vector3 minDectectionRange, maxDetectionRange;
    public GameObject Missile;
    public AudioClip MissileLaunchSound;


    private AudioSource MissileLaunch;
    private bool MissileActive;
    private bool MissileFired;

    private void Awake()
    {
        //LaunchMissile();

        MissileActive = false;
        MissileLaunch = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //only fires missile if player is in circle collision box
        //if (Missile.activeInHierarchy)
        //{
        //    //do nothing?
        //}
        new WaitForSecondsRealtime(2);
        if (collision.tag == "Player" && FieldOfView.CanSeePlayer == true)
            //MissileActive != true
        {
            //if no missile out launches a missile after a delay
            //Invoke("LaunchMissile", 2f);

            LaunchMissile();
            //IsMissileStillActive();
       
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        //Missile.SetActive(true);


    }
    public void LaunchMissile()
    {
        //if the missile is not out and there has been no call to launch a missile already launch a missile
        if (transform.childCount == 0 && MissileActive == false)
        {
            Vector3 MissileSpawnposition = new Vector3(transform.position.x, (transform.position.y + 1), 0);
            MissileActive = true;
            Instantiate(Missile, transform.position, Quaternion.Euler(0, 0, 0), transform);
            //MissileLaunch.Play();
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Made A collision");

        }
        //if there is no missile active but a missile has been fired then tell the launcher that another missile can be fired
        if (transform.childCount == 0 && MissileActive == true)
        {
            MissileActive = false;
        }
    }

    //public void IsMissileStillActive()
    //{
    //    if (Missile.activeInHierarchy == false && MissileActive == true)
    //    {
    //        MissileActive = false;
    //    }
    //}

}





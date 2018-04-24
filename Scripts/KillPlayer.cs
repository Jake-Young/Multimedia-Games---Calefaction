using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public AudioClip PlayerDeathSound; // sound that plays when the player dies
    public GameObject Deathmenu;
    private AudioSource PlayerDeath;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //HotAndCold.instance.TurnCold();
           // Destroy(other.gameObject);//destorys the player
            Debug.Log("Player Dead - reload scene");
            //instance the audiomanager and play the sound
            //AudioManager.instance.PlaySound("thud");
            //ReloadScene();
            //PlayerDeath.Play();
            Deathmenu.SetActive(true);


        }
    }
    void OpenDeathMenu()
    {
        Deathmenu.SetActive(true);
    }
}

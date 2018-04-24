using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //complete level thingy
            Invoke("PlayNextLevel", 3);
            Debug.Log("Level Complete");

        }
    }

    private void PlayNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            Application.Quit();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

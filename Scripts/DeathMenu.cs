using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public GameObject DeathMenuUI;
    public GameObject ResetButton;
    public GameObject ExitButton;
    public GameObject QuitButton;
    public GameObject DontQuitButton;
    public GameObject QuitText;
    

	
	// Update is called once per frame
	void Update () {
        if(PlatformerCharacter2D.IsAlive == false)
        {
            DeathMenuUI.SetActive(true);
        }
	}

    public void BringUpExitGameMenu()
    {
        QuitButton.SetActive(true);
        DontQuitButton.SetActive(true);
        QuitText.SetActive(true);
        ExitButton.SetActive(false);
        ResetButton.SetActive(false);
    }

    public void CloseExitGameMenu()
    {
        QuitButton.SetActive(false);
        DontQuitButton.SetActive(false);
        QuitText.SetActive(false);
        ExitButton.SetActive(true);
        ResetButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        DeathMenuUI.SetActive(true);
        QuitButton.SetActive(false);
        DontQuitButton.SetActive(false);
        QuitText.SetActive(false);
        ExitButton.SetActive(true);
        ResetButton.SetActive(true);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //make character unable to move
    public void OpenDeathMenu()
    {

    }
}

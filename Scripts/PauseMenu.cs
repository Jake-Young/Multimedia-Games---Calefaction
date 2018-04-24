using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject DeathMenu;
    public GameObject PauseMenuUI;
    public GameObject ExitButton;
    public GameObject OptionsButton;
    public GameObject ResumeButton;
    public GameObject Quitbutton;
    public GameObject DontQuitButton;
    public GameObject QuitText;


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && DeathMenu.activeInHierarchy == false)
        {
            //If the game is not paused when you hit the escape key pause the game.
            //Else resume the game
            if (GameIsPaused == true)
            {
                if(DontQuitButton.activeInHierarchy == true)
                {
                    DontQuit();
                }
                else
                {
                    Resume();
                }

            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        //sets time back to normal
        Time.timeScale = 1.0f;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        //Pauses time
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        ExitButton.SetActive(false);
        OptionsButton.SetActive(false);
        ResumeButton.SetActive(false);
        DontQuitButton.SetActive(true);
        Quitbutton.SetActive(true);
        QuitText.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void DontQuit()
    {
        ExitButton.SetActive(true);
        OptionsButton.SetActive(true);
        ResumeButton.SetActive(true);
        DontQuitButton.SetActive(false);
        Quitbutton.SetActive(false);
        QuitText.SetActive(false);
    }

    public void OpenMenu()
    {

    }

}

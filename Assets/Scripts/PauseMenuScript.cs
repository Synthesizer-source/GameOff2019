using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public Button buttonSound;
    bool isSoundOn;


	// Use this for initialization
	void Start () {
        gameIsPaused = false;
        isSoundOn = true;
        if (isSoundOn)
        {
            buttonSound.GetComponentInChildren<Text>().text = "SOUND OFF";
        }
        else
        {
            buttonSound.GetComponentInChildren<Text>().text = "SOUND ON";
        }

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Sound()
    {
        
        AudioSource[] audioSources=FindObjectsOfType<AudioSource>();
        
        foreach (var item in audioSources)
        {
            if (isSoundOn)
            {
                item.enabled = false;
                //item.Pause();
                
            }
            else
            {
                item.enabled = true;
                //item.Play();
                

            }
        }

        if (isSoundOn)
        {
            isSoundOn = false;
        }
        else
        {
            isSoundOn = true;
        }

        if (isSoundOn)
        {
            buttonSound.GetComponentInChildren<Text>().text = "SOUND OFF";
        }
        else
        {
            buttonSound.GetComponentInChildren<Text>().text = "SOUND ON";
        }


        
    }

    public void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        
    }
    public void Exit()
    {

        Application.Quit();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioMainMusic;
    bool isPlay;
    public GameObject mainMenu;

    void Start()
    {
        Time.timeScale = 0f;
    }


    // Use this for initialization
    void Awake   () {
        isPlay = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = audioMainMusic;

        audioSource.Play();
        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        
        
	}

    public void Play()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

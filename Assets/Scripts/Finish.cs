﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelComplete = false;

    public int levelToUnlock;
    int numberofUnlockedLevels;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"  && !levelComplete)
        {
            numberofUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if(numberofUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberofUnlockedLevels + 1);
            }
            finishSound.Play();           
            levelComplete = true;
            Invoke("CompleteLevel", 0.5f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

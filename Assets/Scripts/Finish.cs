using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelComplete = false;

    public int levelToUnlock;
    int numberofUnlockedLevels;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"  && !levelComplete)
        {
            numberofUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if(numberofUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberofUnlockedLevels + 1);
            }         
            levelComplete = true;
            Invoke("CompleteLevel", 0.5f);
        }
    }

    private void CompleteLevel()
    {
        DataManager.ins.currentTime = DataManager.ins.maxTime;
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

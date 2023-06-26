using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController ins;

    public PlayerMovement player;
    public bool addScore;

    private void Awake()
    {
        if(ins != null)
        {
            Destroy(gameObject);
        }
        else {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Update()
    {
        TimeUpdate();
    }

    public void CheckWinLose()
    {
        if(DataManager.ins.currentTime <= 0)
        {
            DataManager.ins.timeActive = false;
            UIController.ins.ShowGameOver();
            ((GameOverScreen)UIController.ins.currentScreen).ScoreGame();
        }
    }

    public void TimeUpdate()
    {
        if (DataManager.ins.timeActive)
        {
            DataManager.ins.currentTime -= Time.deltaTime;
            ((UIGame)UIController.ins.currentScreen).UpdateTimeText();
            AddScore();
            CheckWinLose();
        }
    }

    public void AddScore()
    {
        if(addScore)
        {
            DataManager.ins.score += 7;
            addScore = false;
            DataManager.ins.SaveScore();
            ((UIGame)UIController.ins.currentScreen).UpdateScoreText();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelUp : UIScreenBase
{
    public Text scoreText;
    public Text timeText;

    public override void OnShow()
    {
        base.OnShow();
        ScoreGame();
    }
    public void ScoreGame()
    {
        scoreText.text = DataManager.ins.score.ToString();
    }

    public void TimeFinal()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void LevelComplete()
    {
        DataManager.ins.StartDataGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIController.ins.ShowGame();
    }

    public void Menu()
    {
        Hide();
        DataManager.ins.timeActive = false;
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.ResetDataGame();
    }
}

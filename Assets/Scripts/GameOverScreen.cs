using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : UIScreenBase
{
    public Text scoreText;

    public override void OnShow()
    {
        base.OnShow();
        ScoreGame();
    }
    public void ScoreGame()
    {
        scoreText.text = DataManager.ins.score.ToString();
    }

    public void RestartGame()
    {
        DataManager.ins.StartDataGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
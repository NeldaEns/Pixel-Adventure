using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIGame : UIScreenBase
{
    public Text txtScore;
    public Text txtCurrentTime;

    private void Start()
    {
        UpdateScoreText();
        UpdateTimeText();
    }

    public void Update()
    {
        UpdateScoreText();
        UpdateTimeText();       
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.score.ToString();
    }

    public void UpdateTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        txtCurrentTime.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void Back()
    {
        Hide();
        DataManager.ins.timeActive = false;
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

    public override void OnShow()
    {
        base.OnShow();
        UpdateScoreText();
    }

}

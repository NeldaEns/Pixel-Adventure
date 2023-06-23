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
    }

    public void Update()
    {
        UpdateTimeText();       
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.score.ToString();
    }

    public void UpdateTimeText()
    {
        if (DataManager.ins.timeActive == true)
        {
            DataManager.ins.currentTime = DataManager.ins.currentTime - Time.deltaTime;
            if(DataManager.ins.currentTime <= 0)
            {
                DataManager.ins.timeActive = false;              
            }
        }

        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        txtCurrentTime.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void Back()
    {
        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

    public override void OnShow()
    {
        base.OnShow();
        UpdateScoreText();
    }

}

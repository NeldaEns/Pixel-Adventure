using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelUp : UIScreenBase
{
    [HideInInspector]
    public Text txtDiamond;
    public Text timeText;

    public override void OnShow()
    {
        base.OnShow();
        UpdateDiamondText();
        TimeFinal();
    }

    public void UpdateDiamondText()
    {
        txtDiamond.text = DataManager.ins.diamond.ToString();
    }

    public void TimeFinal()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void LevelComplete()
    {
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIController.ins.ShowUIGame();
        ((UIGame)UIController.ins.currentScreen).tetx.SetActive(false);
    }

    public void Menu()
    {
        Hide();
        DataManager.ins.timeActive = false;
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.DataGame();
    }
}

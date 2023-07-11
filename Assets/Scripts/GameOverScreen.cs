using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameOverScreen : UIScreenBase
{
    public Text txtApple;
    public Text txtBanana;
    public Text txtCherries;
    public Text txtKiwi;
    public Text txtMelon;
    public Text txtOrange;
    public Text txtPineapple;
    public Text txtStrawberry;
    public Text txtDiamond;
    public Text timeText;
 

    public override void OnShow()
    {
        base.OnShow();
        UpdateAppleText();
        UpdateBananaText();
        UpdateCherriesText();
        UpdateKiwiText();
        UpdateMelonText();
        UpdatePineappleText();
        UpdateOrangeText();
        UpdateStrawberryText();
        TimeFinal();
    }
    public void UpdateAppleText()
    {
        txtApple.text = DataManager.ins.apple.ToString();
    }

    public void UpdateBananaText()
    {
        txtBanana.text = DataManager.ins.banana.ToString();
    }

    public void UpdateCherriesText()
    {
        txtCherries.text = DataManager.ins.cherries.ToString();
    }

    public void UpdateKiwiText()
    {
        txtKiwi.text = DataManager.ins.kiwi.ToString();
    }

    public void UpdateMelonText()
    {
        txtMelon.text = DataManager.ins.melon.ToString();
    }

    public void UpdateStrawberryText()
    {
        txtStrawberry.text = DataManager.ins.strawberry.ToString();
    }

    public void UpdatePineappleText()
    {
        txtPineapple.text = DataManager.ins.pineapple.ToString();
    }

    public void UpdateDiamondText()
    {
        txtDiamond.text = DataManager.ins.diamond.ToString();
    }

    public void UpdateOrangeText()
    {
        txtOrange.text = DataManager.ins.orange.ToString();
    }
    public void TimeFinal()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void RestartGame()
    {
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIController.ins.ShowUIGame();
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
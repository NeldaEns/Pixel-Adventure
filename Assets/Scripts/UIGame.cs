﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIGame : UIScreenBase
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
    public Text txtCurrentTime;
    public Text txtHealth;
    public Joystick joyStick;

    private void Start()
    {
        UpdateAppleText();
        UpdateBananaText();
        UpdateCherriesText();
        UpdateKiwiText();
        UpdateMelonText();
        UpdatePineappleText();
        UpdateStrawberryText();
        UpdateOrangeText();
        UpdateDiamondText();
        UpdateTimeText();
        UpdateHeart();
    }

    public void Update()
    {
        UpdateAppleText();
        UpdateBananaText();
        UpdateCherriesText();
        UpdateKiwiText();
        UpdateMelonText();
        UpdatePineappleText();
        UpdateStrawberryText();
        UpdateOrangeText();
        UpdateDiamondText();
        UpdateTimeText();
        UpdateHeart();
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

    public void UpdateOrangeText()
    {
        txtOrange.text = DataManager.ins.orange.ToString();
    }

    public void UpdateDiamondText()
    {
        txtDiamond.text = DataManager.ins.diamond.ToString();
    }

    public void UpdateTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        txtCurrentTime.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void UpdateHeart()
    {
        txtHealth.text = DataManager.ins.health.ToString();
    }

    public void Back()
    {
        DataManager.ins.timeActive = false;
    }

    public override void OnShow()
    {
        base.OnShow();
        UpdateAppleText();
        UpdateBananaText();
        UpdateCherriesText();
        UpdateKiwiText();
        UpdateMelonText();
        UpdatePineappleText();
        UpdateStrawberryText();
        UpdateOrangeText();
        UpdateDiamondText();
        UpdateHeart();
        UpdateTimeText();
    }

    public void OnButtonJumpClick()
    {
        GameController.ins.PlayerJump();
    }

    public void Continue()
    {
        DataManager.ins.timeActive = true;
    }

    public void Restart()
    {
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Hide();
        DataManager.ins.timeActive = false;
        SceneManager.LoadScene(0);
        UIController.ins.ShowMenu();
    }
}

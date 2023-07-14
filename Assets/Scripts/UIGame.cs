using System.Collections;
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

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emmtyHeart;

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
        foreach(Image img in hearts)
        {
            img.sprite = emmtyHeart;
        }
        for(int i = 0; i < DataManager.ins.health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
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
    }

    public void OnButtonJumpClick()
    {
        GameController.ins.PlayerJump();
    }

    public void PointDownLeftButton()
    {
        GameController.ins.moveLeft = true;
    }

    public void PointUpLeftButton()
    {
        GameController.ins.moveLeft = false;
    }

    public void PointDownRightButton()
    {
        GameController.ins.moveRight = true;
    }

    public void PointUpRightButton()
    {
        GameController.ins.moveRight = false;
    }
}

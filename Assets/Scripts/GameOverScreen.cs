using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Text txtCurrentTime;

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGame : UIScreenBase
{
    public Text txtScore;

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.score.ToString();
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

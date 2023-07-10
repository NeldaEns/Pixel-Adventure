using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUI : UIScreenBase
{
    public int sceneIndex;
    public void OpenLv()
    {
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;       
        SceneManager.LoadScene(sceneIndex);
        UIController.ins.ShowUIGame();       
    }

    public override void OnShow()
    {
        base.OnShow();
    }

    public override void Hide()
    {
        base.Hide();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUI : UIScreenBase
{
    public int sceneIndex;
    public Text DiamondTxt;


    //private void Start()
    //{
    //    UpdateDiamond();
    //}
    public void OpenLv()
    {
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;       
        SceneManager.LoadScene(sceneIndex);
        UIController.ins.ShowUIGame();       
    }

    //public void UpdateDiamond()
    //{
    //    DiamondTxt.text = DataManager.ins.diamond.ToString();
    //}

    public override void OnShow()
    {
        //UpdateDiamond();
        base.OnShow();
    }

    public override void Hide()
    {
        base.Hide();
    }
}

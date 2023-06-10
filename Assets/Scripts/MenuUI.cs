using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUI : UIScreenBase
{
    public void OpenLv()
    {
        SceneManager.LoadScene(1);
        Debug.Log(14);
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

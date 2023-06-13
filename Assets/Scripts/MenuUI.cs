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
        SceneManager.LoadScene(sceneIndex);
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

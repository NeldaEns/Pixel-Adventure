using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int levelToUnlock;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" /*&& !GameController.ins.levelComple*/)
        {
            GameController.ins.levelComple = true;
            DataManager.ins.LoadLevelsUnlocked();
            if(DataManager.ins.numberofUnlockedLevels <= levelToUnlock)
            {
                DataManager.ins.SaveLevelsUnlocked();              
            }
        }
    }
}

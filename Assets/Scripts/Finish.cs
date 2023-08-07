using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int levelToUnlock;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            AudioManager.ins.PlaySFX("levelcomplete");
            GameController.ins.levelComple = true;
            if (GameController.ins.apple.Length == 0 && GameController.ins.banana.Length == 0 && GameController.ins.cherries.Length == 0 && GameController.ins.kiwi.Length == 0
                && GameController.ins.orange.Length == 0 && GameController.ins.melon.Length == 0 && GameController.ins.pineapple.Length == 0 && GameController.ins.strawberry.Length == 0)
            {
                DataManager.ins.LoadLevelsUnlocked();
                if (DataManager.ins.numberofUnlockedLevels <= levelToUnlock)
                {
                    DataManager.ins.SaveLevelsUnlocked();
                }
            }
        }
    }
}

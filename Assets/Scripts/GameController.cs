using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController ins;

    public PlayerLife player;

    private void Awake()
    {
        if(ins != null)
        {
            Destroy(gameObject);
        }
        else {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Update()
    {
        CheckWinLose();
    }

    public void CheckWinLose()
    {
        if(DataManager.ins.currentTime <= 0)
        {
            DataManager.ins.timeActive = false;
            player.Die();
            player.RestartLevel();
        }
    }
}

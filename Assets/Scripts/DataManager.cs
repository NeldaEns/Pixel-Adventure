using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;

    public int score;


    public const string levelsUnlocked = "levelsUnlocked";
    public const string score_key = "score_key";

    private void Awake()
    {
        if(ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt(score_key, 0);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(score_key, score);
    }
}

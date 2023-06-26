using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;

    public int score;
    public float currentTime;
    public float maxTime = 90f;
    public const string levelsUnlocked = "levelsUnlocked";
    public const string score_key = "score_key";
    public const string first_time_play = "first_time_play";
    public const string time_key = "time_key";

    public bool timeActive = false;

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
        FirstTimePlay();
    }

    private void Start()
    {
        currentTime = maxTime;
    }

    public void FirstTimePlay()
    {
        if(PlayerPrefs.HasKey(first_time_play))
        {
            LoadDataGame();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play, 0);
            StartDataGame();
        }
    }

    public void LoadDataGame()
    {
        LoadScore();
        LoadTime();
    }

    public void StartDataGame()
    {
        score = 0;
        currentTime = maxTime;
        timeActive = true;
        SaveTime();
        SaveScore();
    }

    public void ResetDataGame()
    {
        score = 0;
        currentTime = maxTime;
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt(score_key, 0);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(score_key, score);
    }

    public void LoadTime()
    {
        currentTime = PlayerPrefs.GetFloat(time_key, 0);
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat(time_key, currentTime);
    }

}

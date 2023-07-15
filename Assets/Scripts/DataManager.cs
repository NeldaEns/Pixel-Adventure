using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;

    public int apple;
    public int banana;
    public int cherries;
    public int kiwi;
    public int melon;
    public int orange;
    public int pineapple;
    public int strawberry;
    public int diamond;
    public int numberofUnlockedLevels;
    public int health = 3;

    public float currentTime;
    public float maxTime = 90f;

    public const string levelsUnlocked = "levelsUnlocked";
    public const string apple_key = "apple_key";
    public const string banana_key = "banana_key";
    public const string kiwi_key = "kiwi_key";
    public const string cherries_key = "cherries_key";
    public const string melon_key = "melon_key";
    public const string orange_key = "orange_key";
    public const string pineapple_key = "pineapple_key";
    public const string strawberry_key = "strawberry_key";
    public const string diamond_key = "diamond_key";
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
        LoadApple();
        LoadBanana();
        LoadCherries();
        LoadKiwi();
        LoadMelon();
        LoadOrange();
        LoadStrawberry();
        LoadPineapple();
        LoadTime();
        LoadDiamond();
    }

    public void StartDataGame()
    {
        apple = 0;
        banana = 0;
        cherries = 0;
        kiwi = 0;
        melon = 0;
        orange = 0;
        pineapple = 0;
        strawberry = 0;
        diamond = 0;
        currentTime = maxTime;
        SaveTime();
        SaveApple();
        SaveBanana();
        SaveCherries();
        SaveKiwi();
        SaveMelon();
        SaveOrange();
        SavePineapple();
        SaveStrawberry();
        SaveDiamond();
    }   

    public void DataGame()
    {
        health = 3;
        apple = 0;
        banana = 0;
        cherries = 0;
        kiwi = 0;
        melon = 0;
        orange = 0;
        pineapple = 0;
        strawberry = 0;
        currentTime = maxTime;
    }

    public void LoadApple()
    {
        apple = PlayerPrefs.GetInt(apple_key);
    }
    public void SaveApple()
    {
        PlayerPrefs.SetInt(apple_key, apple);
    }

    public void LoadBanana()
    {
        banana = PlayerPrefs.GetInt(banana_key);
    }
    public void SaveBanana()
    {
        PlayerPrefs.SetInt(banana_key, banana);
    }

    public void LoadCherries()
    {
        cherries = PlayerPrefs.GetInt(cherries_key);
    }
    public void SaveCherries()
    {
        PlayerPrefs.SetInt(cherries_key, cherries);
    }

    public void LoadKiwi()
    {
        kiwi = PlayerPrefs.GetInt(kiwi_key);
    }
    public void SaveKiwi()
    {
        PlayerPrefs.SetInt(kiwi_key, kiwi);
    }

    public void LoadMelon()
    {
        melon = PlayerPrefs.GetInt(melon_key);
    }
    public void SaveMelon()
    {
        PlayerPrefs.SetInt(melon_key, melon);
    }

    public void LoadOrange()
    {
        orange = PlayerPrefs.GetInt(orange_key);
    }
    public void SaveOrange()
    {
        PlayerPrefs.SetInt(orange_key, orange);
    }

    public void LoadPineapple()
    {
        pineapple = PlayerPrefs.GetInt(pineapple_key);
    }
    public void SavePineapple()
    {
        PlayerPrefs.SetInt(pineapple_key, pineapple);
    }

    public void LoadStrawberry()
    {
        strawberry = PlayerPrefs.GetInt(strawberry_key);
    }
    public void SaveStrawberry()
    {
        PlayerPrefs.SetInt(strawberry_key, strawberry);
    }

    public void LoadDiamond()
    {
        diamond = PlayerPrefs.GetInt(diamond_key);
    }
    public void SaveDiamond()
    {
        PlayerPrefs.SetInt(diamond_key, diamond);
    }

    public void LoadTime()
    {
        currentTime = PlayerPrefs.GetFloat(time_key, 0);
    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat(time_key, currentTime);
    }

    public void LoadLevelsUnlocked()
    {
        numberofUnlockedLevels = PlayerPrefs.GetInt(levelsUnlocked);
    }
    public void SaveLevelsUnlocked()
    {
        PlayerPrefs.SetInt(levelsUnlocked, numberofUnlockedLevels + 1);
    }

}

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
    public int health ;
    public int selectedCharacter;

    public float musicVolume;
    public float sfxVolume;
    public float currentTime;
    public float maxTime;
    public float musicSliderValue;
    public float sfxSliderValue;

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
    public const string selected_character = "selected_character";
    public const string music_volume = "music_volume";
    public const string sfx_volume = "sfx_volume";
    private const string music_slider_value = "music_slider_value";
    private const string sfx_slider_value = "sfx_slider_value";

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
        sfxSliderValue = 1;
        musicSliderValue = 1;
        FirstTimePlay();
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
        LoadDiamond();
        LoadSelectedCharacter();
        LoadSFXVolume();
        LoadMusicVolume();
        LoadSFXSliderValue();
        LoadMusicSliderValue();
    }

    public void StartDataGame()
    {
        musicVolume = 1f;
        sfxVolume = 1f;
        diamond = 799;
        currentTime = maxTime;
        SaveDiamond();
        SaveMusicVolume();
        SaveSFXVolume();
        SaveMusicSliderValue();
        SaveSFXSliderValue();
    }   

    public void DataGame()
    {
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
        diamond = PlayerPrefs.GetInt(diamond_key, 0);
    }
    public void SaveDiamond()
    {
        PlayerPrefs.SetInt(diamond_key, diamond);
    }

    public void LoadLevelsUnlocked()
    {
        numberofUnlockedLevels = PlayerPrefs.GetInt(levelsUnlocked);
    }
    public void SaveLevelsUnlocked()
    {
        PlayerPrefs.SetInt(levelsUnlocked, numberofUnlockedLevels + 1);
    }

    public void LoadSelectedCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt(selected_character, 0);
    }
    public void SaveSelectedCharacter()
    {
        PlayerPrefs.SetInt(selected_character, selectedCharacter);
    }

    public void LoadMusicVolume()
    {
        musicVolume = PlayerPrefs.GetFloat(music_volume);
    }
    public void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat(music_volume, musicVolume);
    }

    public void LoadSFXVolume()
    {
        sfxVolume = PlayerPrefs.GetFloat(sfx_volume);
    }
    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat(sfx_volume, sfxVolume);
    }

    public void LoadSFXSliderValue()
    {
        sfxSliderValue = PlayerPrefs.GetFloat(sfx_slider_value);
    }
    public void SaveSFXSliderValue()
    {
        PlayerPrefs.SetFloat(sfx_slider_value, sfxSliderValue);
    }

    public void LoadMusicSliderValue()
    {
        musicSliderValue = PlayerPrefs.GetFloat(music_slider_value);
    }
    public void SaveMusicSliderValue()
    {
        PlayerPrefs.SetFloat(music_slider_value, musicSliderValue);
    }
}

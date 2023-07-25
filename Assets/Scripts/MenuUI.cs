using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class MenuUI : UIScreenBase
{
    public int sceneIndex;
    [SerializeField] public Slider musicSlider, sfxSlider;
    public Text diamondTxt;
    public UnityAction<bool> x;

    private void Start()
    {
        UpdateDiamondText();
        sfxSlider.value = DataManager.ins.sfxSliderValue;
        DataManager.ins.sfxVolume = sfxSlider.value;
        AudioManager.ins.SFXVolume(sfxSlider.value);
        musicSlider.value = DataManager.ins.musicSliderValue;
        DataManager.ins.musicVolume = musicSlider.value;
        AudioManager.ins.MusicVolume(musicSlider.value);
    }
    private void Update()
    {
        UpdateDiamondText();
    }
    public void OpenLv()
    {
        AudioManager.ins.PlaySFX("click");
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;       
        SceneManager.LoadScene(sceneIndex);
        UIController.ins.ShowUIGame();       
    }

    public void WatchAds()
    {
        ManagerAds.Ins.ShowRewardedVideo((x) =>
        {
            if(x)
            {
                AudioManager.ins.PlaySFX("diamond");
                DataManager.ins.diamond += 30;
                DataManager.ins.SaveDiamond();
            }
        });
    }

    public void MusicVolume()
    {
        DataManager.ins.musicVolume = musicSlider.value;
        DataManager.ins.SaveMusicVolume();
        DataManager.ins.musicSliderValue = musicSlider.value;
        DataManager.ins.SaveMusicSliderValue();
        AudioManager.ins.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        DataManager.ins.sfxVolume = sfxSlider.value;
        DataManager.ins.SaveSFXVolume();
        DataManager.ins.sfxSliderValue = sfxSlider.value;
        DataManager.ins.SaveSFXSliderValue();
        AudioManager.ins.SFXVolume(sfxSlider.value);
    }

    public void UpdateDiamondText()
    {
        diamondTxt.text = DataManager.ins.diamond.ToString();
    }

    public void ClickButton()
    {
        AudioManager.ins.PlaySFX("click");
    }

    public override void OnShow()
    {
        base.OnShow();
        UpdateDiamondText();
    }

    public override void Hide()
    {
        base.Hide();
    }
}

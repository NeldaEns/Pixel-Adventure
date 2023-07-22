using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUI : UIScreenBase
{
    public int sceneIndex;
    [SerializeField] public Slider musicSlider, sfxSlider;

    private void Start()
    {
        sfxSlider.value = DataManager.ins.sfxSliderValue;
        DataManager.ins.sfxVolume = sfxSlider.value;
        AudioManager.ins.SFXVolume(sfxSlider.value);
        musicSlider.value = DataManager.ins.musicSliderValue;
        DataManager.ins.musicVolume = musicSlider.value;
        AudioManager.ins.MusicVolume(musicSlider.value);
    }
    public void OpenLv()
    {
        AudioManager.ins.PlaySFX("click");
        DataManager.ins.DataGame();
        DataManager.ins.timeActive = true;       
        SceneManager.LoadScene(sceneIndex);
        UIController.ins.ShowUIGame();       
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

    public void ClickButton()
    {
        AudioManager.ins.PlaySFX("click");
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

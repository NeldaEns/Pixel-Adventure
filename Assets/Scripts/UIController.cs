using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController ins;
    [HideInInspector]
    public UIScreenBase currentScreen;
    public GameObject mainMenu;
    public GameObject gamePanel;
    public GameObject bg;
    public GameObject mainCamera;
    public GameObject gameOverPanel;
    public GameObject levelComplete;


    private void Awake()
    {
        if(ins != null)
        {
            Destroy(gameObject);
            Destroy(mainCamera);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(mainCamera);
        }
        mainCamera.GetComponent<AudioListener>().enabled = mainCamera.GetComponent<AudioListener>().enabled;

    }

    private void Start()
    {
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        currentScreen = Instantiate(mainMenu, transform).GetComponent<MenuUI>();
    }

    public void ShowMenu()
    {
        mainCamera.GetComponent<AudioListener>().enabled = true;
        bg.SetActive(true);
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(mainMenu, transform).GetComponent<MenuUI>();
    }

    public void ShowUIGame()
    {
        mainCamera.GetComponent<AudioListener>().enabled = false;
        bg.SetActive(false);
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(gamePanel, transform).GetComponent<UIGame>();
    }

    public void ShowGameOver()
    {
        mainCamera.GetComponent<AudioListener>().enabled = false;
        bg.SetActive(false);
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(gameOverPanel, transform).GetComponent<GameOverScreen>();
    }

    public void ShowLevelUp()
    {
        mainCamera.GetComponent<AudioListener>().enabled = false;
        bg.SetActive(false);
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(levelComplete, transform).GetComponent<LevelUp>();
    }
    
}

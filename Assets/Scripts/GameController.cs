using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController ins;
    public GameObject startPoint;

    public GameObject[] apple;
    public GameObject[] cherries;
    public GameObject[] banana;
    public GameObject[] kiwi;
    public GameObject[] orange;
    public GameObject[] melon;
    public GameObject[] pineapple;
    public GameObject[] strawberry;
    public GameObject[] diamond;

    [HideInInspector]
    public bool addApple, addBanana, addCherries, addKiwi, addMelon, addOrange, addPineapple, addStrawberry, addDiamond;
    public bool levelComple;
    public bool gamePlay;
    public bool moveLeft;
    public bool moveRight;
    public bool isGrounded;
    public bool doubleJump;

    public Transform[] playerPrefabs;

    public int characterIndex;

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
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }

    private void Start()
    {
        UpdateQuantityFruit();
        Instantiate(playerPrefabs[characterIndex], startPoint.transform.position, Quaternion.identity);
    }


    private void Update()
    {
        TimeUpdate();
        UpdateQuantityFruit();
    }

    public void CheckWinLose()
    {
        if (levelComple)
        {
            DataManager.ins.timeActive = false;
            if (apple.Length > 0 || banana.Length > 0 || cherries.Length > 0 || orange.Length > 0 || melon.Length > 0 || strawberry.Length > 0 || pineapple.Length > 0 || kiwi.Length > 0)
            {
                UIController.ins.ShowGameOver();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateAppleText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateBananaText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateCherriesText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateKiwiText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateMelonText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateOrangeText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdatePineappleText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateStrawberryText();
                ((GameOverScreen)UIController.ins.currentScreen).UpdateDiamondText();
                ((GameOverScreen)UIController.ins.currentScreen).TimeFinal();
                levelComple = false;
            }
            else if (apple.Length == 0 && banana.Length == 0 && cherries.Length == 0 && kiwi.Length == 0 && orange.Length == 0 && melon.Length == 0 && pineapple.Length == 0 && strawberry.Length == 0)
            {
                UIController.ins.ShowLevelUp();
                ((LevelUp)UIController.ins.currentScreen).UpdateAppleText();
                ((LevelUp)UIController.ins.currentScreen).UpdateBananaText();   
                ((LevelUp)UIController.ins.currentScreen).UpdateCherriesText();
                ((LevelUp)UIController.ins.currentScreen).UpdateKiwiText();
                ((LevelUp)UIController.ins.currentScreen).UpdateMelonText();
                ((LevelUp)UIController.ins.currentScreen).UpdateOrangeText();
                ((LevelUp)UIController.ins.currentScreen).UpdatePineappleText();
                ((LevelUp)UIController.ins.currentScreen).UpdateStrawberryText();
                ((LevelUp)UIController.ins.currentScreen).UpdateDiamondText();
                ((LevelUp)UIController.ins.currentScreen).TimeFinal();
                levelComple = false;
            }
        }
        if (DataManager.ins.currentTime <= 0)
        {
            DataManager.ins.timeActive = false;
            UIController.ins.ShowGameOver();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateAppleText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateBananaText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateCherriesText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateKiwiText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateMelonText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateOrangeText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdatePineappleText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateStrawberryText();
            ((GameOverScreen)UIController.ins.currentScreen).UpdateDiamondText();
        }
    }

    public void TimeUpdate()
    {
        if (DataManager.ins.timeActive)
        {
            gamePlay = true;
            DataManager.ins.currentTime -= Time.deltaTime;
            ((UIGame)UIController.ins.currentScreen).UpdateTimeText();
            AddFruit();
            CheckWinLose();
        }
    }

    public void AddFruit()
    {
        if (addApple)
        {
            DataManager.ins.apple -= 1;
            addApple = false;
            DataManager.ins.SaveApple();
            ((UIGame)UIController.ins.currentScreen).UpdateAppleText();
        }
        if (addBanana)
        {
            DataManager.ins.banana -= 1;
            addBanana = false;
            DataManager.ins.SaveBanana();
            ((UIGame)UIController.ins.currentScreen).UpdateBananaText();
        }
        if (addCherries)
        {
            DataManager.ins.cherries -= 1;
            addCherries = false;
            DataManager.ins.SaveCherries();
            ((UIGame)UIController.ins.currentScreen).UpdateCherriesText();
        }
        if (addKiwi)
        {
            DataManager.ins.kiwi -= 1;
            addKiwi = false;
            DataManager.ins.SaveKiwi();
            ((UIGame)UIController.ins.currentScreen).UpdateKiwiText();
        }
        if (addOrange)
        {
            DataManager.ins.orange -= 1;
            addOrange = false;
            DataManager.ins.SaveOrange();
            ((UIGame)UIController.ins.currentScreen).UpdateOrangeText();
        }
        if (addMelon)
        {
            DataManager.ins.melon -= 1;
            addMelon = false;
            DataManager.ins.SaveMelon();
            ((UIGame)UIController.ins.currentScreen).UpdateMelonText();
        }
        if (addPineapple)
        {
            DataManager.ins.pineapple -= 1;
            addPineapple = false;
            DataManager.ins.SavePineapple();
            ((UIGame)UIController.ins.currentScreen).UpdatePineappleText();
        }
        if (addStrawberry)
        {
            DataManager.ins.strawberry -= 1;
            addStrawberry = false;
            DataManager.ins.SaveStrawberry();
            ((UIGame)UIController.ins.currentScreen).UpdateStrawberryText();
        }
        if (addDiamond)
        {
            DataManager.ins.diamond += 1;
            addDiamond = false;
            DataManager.ins.SaveDiamond();
            ((UIGame)UIController.ins.currentScreen).UpdateDiamondText();
        }
    }

    public void UpdateQuantityFruit()
    {
        apple = GameObject.FindGameObjectsWithTag("Apple");
        banana = GameObject.FindGameObjectsWithTag("Banana");
        cherries = GameObject.FindGameObjectsWithTag("Cherry");
        kiwi = GameObject.FindGameObjectsWithTag("Kiwi");
        orange = GameObject.FindGameObjectsWithTag("Orange");
        melon = GameObject.FindGameObjectsWithTag("Melon");
        pineapple = GameObject.FindGameObjectsWithTag("Pineapple");
        strawberry = GameObject.FindGameObjectsWithTag("Strawberry");
        diamond = GameObject.FindGameObjectsWithTag("Diamond");
    }

    public void PlayerJump()
    {
        playerPrefabs[characterIndex].GetComponent<PlayerMovement>().JumpButton();
    }

}

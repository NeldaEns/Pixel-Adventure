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
    public bool isGrounded;
    public bool doubleJump;
    public bool isGameOver;

    public GameObject[] playerPrefabs;
    public PlayerMovement player1;

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
        DataManager.ins.LoadSelectedCharacter();
        GameObject player = Instantiate(playerPrefabs[DataManager.ins.selectedCharacter], startPoint.transform.position, Quaternion.identity);

        SpawnNv();
        isGameOver = false;
    }

    private void Start()
    {
        UpdateQuantityFruit();
    }

    private void Update()
    {
        TimeUpdate();
        UpdateQuantityFruit();
        player1 = FindObjectOfType<PlayerMovement>();
    }

    public void SpawnNv()
    {
        if(DataManager.ins.selectedCharacter == 0)
        {
            DataManager.ins.health = 3;
            DataManager.ins.maxTime = 90;
            DataManager.ins.currentTime = DataManager.ins.maxTime;
        }
        if (DataManager.ins.selectedCharacter == 1)
        {
            DataManager.ins.health = 3;
            DataManager.ins.maxTime = 120;
            DataManager.ins.currentTime = DataManager.ins.maxTime;
        }
        if (DataManager.ins.selectedCharacter == 2)
        {
            DataManager.ins.health = 4;
            DataManager.ins.maxTime = 150;
            DataManager.ins.currentTime = DataManager.ins.maxTime;
        }
        if (DataManager.ins.selectedCharacter == 3)
        {
            DataManager.ins.health = 5;
            DataManager.ins.maxTime = 180;
            DataManager.ins.currentTime = DataManager.ins.maxTime;
        }
    }

    public void CheckWinLose()
    {
        if (levelComple)
        {
            ManagerAds.Ins.ShowInterstitial();
            DataManager.ins.timeActive = false;
            if (apple.Length > 0 || banana.Length > 0 || cherries.Length > 0 || orange.Length > 0 || melon.Length > 0 || strawberry.Length > 0 || pineapple.Length > 0 || kiwi.Length > 0)
            {
                isGameOver = true;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                ((UIGame)UIController.ins.currentScreen).joyStick.ResetValue();
                DataManager.ins.timeActive = true;
                levelComple = false;
            }
        }
        if (DataManager.ins.currentTime <= 0)
        {
            isGameOver = true;
            ManagerAds.Ins.ShowInterstitial();
            AudioManager.ins.PlaySFX("gameover");
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
        DataManager.ins.apple = apple.Length;
        DataManager.ins.banana = banana.Length;
        DataManager.ins.cherries = cherries.Length;
        DataManager.ins.kiwi = kiwi.Length;
        DataManager.ins.orange = orange.Length;
        DataManager.ins.melon = melon.Length;
        DataManager.ins.pineapple = pineapple.Length;
        DataManager.ins.strawberry = strawberry.Length;
    }

    public void PlayerJump()
    {
       player1.JumpButton(); 
    }

}

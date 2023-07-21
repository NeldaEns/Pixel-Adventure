using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : UIScreenBase
{
    public GameObject[] skins;
    public Character[] characters;
    public Button unlockButton;
    public Text diamondTxt;

    private void Awake()
    {
        DataManager.ins.LoadSelectedCharacter();
        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }
            skins[DataManager.ins.selectedCharacter].SetActive(true);

        foreach (Character c in characters)
        {
            if (c.price == 0)
            {
                c.isUnlocked = true;
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }

    private void Start()
    {
        UpdateDiamondText();
    }
    private void Update()
    {
        UpdateDiamondText();
    }

    public void UpdateDiamondText()
    {
        diamondTxt.text = DataManager.ins.diamond.ToString();
    }

    public void ChangeNext()
    {
        skins[DataManager.ins.selectedCharacter].SetActive(false);
        DataManager.ins.selectedCharacter++;
        if (DataManager.ins.selectedCharacter == skins.Length)
        {
            DataManager.ins.selectedCharacter = 0;
        }
        skins[DataManager.ins.selectedCharacter].SetActive(true);
        if(characters[DataManager.ins.selectedCharacter].isUnlocked)
        {
        DataManager.ins.SaveSelectedCharacter();
        }
        UpdateUI();
    }

    public void ChangePrevious()
    {
        skins[DataManager.ins.selectedCharacter].SetActive(false);
        DataManager.ins.selectedCharacter--;
        if(DataManager.ins.selectedCharacter == -1)
        {
            DataManager.ins.selectedCharacter = skins.Length - 1;
        }
        skins[DataManager.ins.selectedCharacter].SetActive(true);
        if (characters[DataManager.ins.selectedCharacter].isUnlocked)
        {
        DataManager.ins.SaveSelectedCharacter();
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(characters[DataManager.ins.selectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[DataManager.ins.selectedCharacter].price;
            if(DataManager.ins.diamond < characters[DataManager.ins.selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;   
            }
        }
    }

    public void Unlocked()
    {
        int price = characters[DataManager.ins.selectedCharacter].price;
        DataManager.ins.diamond = DataManager.ins.diamond - price;
        DataManager.ins.SaveDiamond();
        PlayerPrefs.SetInt(characters[DataManager.ins.selectedCharacter].name, 1);
        DataManager.ins.SaveSelectedCharacter();
        characters[DataManager.ins.selectedCharacter].isUnlocked = true;
        UpdateUI();
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

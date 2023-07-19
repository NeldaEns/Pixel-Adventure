using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;
    public Button unlockButton;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject player in skins)
        {
            player.SetActive(false);

            skins[selectedCharacter].SetActive(true);
        }

        foreach(Character c in characters)
        {
            if(c.price == 0)
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

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
        {
            selectedCharacter = 0;
        }
        skins[selectedCharacter].SetActive(true);
        if(characters[selectedCharacter].isUnlocked)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter == -1)
        {
            selectedCharacter = skins.Length - 1;
        }
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }
    }

    public void UpdateUI()
    {
        if(characters[selectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            if(DataManager.ins.diamond < characters[selectedCharacter].price)
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
        int price = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("diamond_key", DataManager.ins.diamond - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        UpdateUI();
    }
}

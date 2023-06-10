using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    int unlockedLevelsNumber;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocker");

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }
    }

    private void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocker");
        for (int i = 0; i < unlockedLevelsNumber; i++)
        {
            buttons[i].interactable = true;
        }
    }
}

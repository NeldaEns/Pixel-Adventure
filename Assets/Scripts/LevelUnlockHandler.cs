using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> levelButtons;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("levelsUnlocked") == 0)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
    }

    private void Start()
    {
        for(int i = 0; i < levelButtons.Count; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = false;
        }

        for(int i = 1; i <= PlayerPrefs.GetInt("levelsUnlocked"); i++)
        {
            levelButtons[i - 1].GetComponent<Button>().interactable = true;
        }
    }
}

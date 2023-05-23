using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSyntasis : MonoBehaviour
{
    [SerializeField] int gameLevel;
    int countLevels = 4;
    [SerializeField] GameObject[] levelHolder;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasControl;
    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;

    void Update()
    {
        if (canvasMiniGame == true)
        {
            canvasControl.SetActive(false);
        }
        else
        {
            canvasControl.SetActive(true);
        }
    }

    public void ActivateGameLevel()
    {
        if (gameLevel == countLevels)
        {
            BeforeDialogueObject.SetActive(false);
            AfterDialogueObject.SetActive(true);
        }

        if (gameLevel != 0)
        {
            levelHolder[gameLevel - 1].SetActive(false);
        }
        levelHolder[gameLevel].SetActive(true);
    }

    public void GameLevelIncrease()
    {
        gameLevel++;
    }
}

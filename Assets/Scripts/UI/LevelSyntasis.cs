using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSyntasis : MonoBehaviour
{
    [SerializeField] int gameLevel;
    [SerializeField] int countLevels;
    [SerializeField] GameObject[] levelHolder;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasControl;
    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;

    void Update()
    {
        if (gameLevel == countLevels)
        {
            BeforeDialogueObject.SetActive(false);
            AfterDialogueObject.SetActive(true);
            canvasMiniGame.SetActive(false);
            canvasControl.SetActive(true);
        }
    }

    public void ActivateGameLevel()
    {
        if (gameLevel != 0)
        {
            levelHolder[gameLevel - 1].SetActive(false);
            if(gameLevel < countLevels)
                levelHolder[gameLevel].SetActive(true);
        }       
    }

    public void GameLevelIncrease()
    {
        gameLevel++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSyntasis : MonoBehaviour
{
    [SerializeField] int gameLevel;
    [SerializeField] GameObject[] levelHolder;
    public void ActivateGameLevel()
    {
        if(gameLevel != 0)
        {
            levelHolder[gameLevel-1].SetActive(false);
        }
        levelHolder[gameLevel].SetActive(true);       
    }
    public void GameLevelIncrease()
    {
        gameLevel++;
    }
}

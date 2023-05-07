using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSyntasis : MonoBehaviour
{
    [SerializeField] int gameLevel;
    [SerializeField] GameObject[] levelHolder;
    public void ActivateGameLevel()
    {
        levelHolder[gameLevel].SetActive(true);
    }
    public void GameLevelIncrease()
    {
        gameLevel++;
    }
}

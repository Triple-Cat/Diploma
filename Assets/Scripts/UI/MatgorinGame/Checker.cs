using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour
{
    [SerializeField] LevelSyntasis levelSyntasis;
    public int sumAnswer;
    public int needSumAnswer;

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] Button buttonInteractable;


    public void Result()
    {
        buttonInteractable.interactable = false;
        if (sumAnswer == needSumAnswer)
        {
            tipsCorrectly.SetActive(true);
            Invoke("InvTipsCorrectly", 2f);
        }
        else
        {
            tipsUncorrectly.SetActive(true);
            Invoke("InvTipsUncorrectly", 2f);
        }
    }

    private void InvTipsUncorrectly()
    {
        buttonInteractable.interactable = true;

        tipsUncorrectly.SetActive(false);
    }
    private void InvTipsCorrectly()
    {
        tipsCorrectly.SetActive(false);
        levelSyntasis.GameLevelIncrease();
        levelSyntasis.ActivateGameLevel();
    }
}

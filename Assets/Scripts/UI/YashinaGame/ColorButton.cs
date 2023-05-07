using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] LevelSyntasis levelSyntasis;

    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsNotCompleted;

    [SerializeReference] GameObject canvasSyntesisGame;

    [SerializeField] private int correctlyAnswerCount;
    [SerializeField] private int amountNededCorrectlyAnswer;

    public void CorrectAnswer()
    {
        correctlyAnswerCount++;
    }

    public void UnCorrectAnswer()
    {

    }

    public void CheckAnswer()
    {
        if (correctlyAnswerCount == amountNededCorrectlyAnswer)
        {
            levelSyntasis.GameLevelIncrease();
            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }
        if (correctlyAnswerCount == 0)
        {
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
        else if(correctlyAnswerCount != amountNededCorrectlyAnswer && correctlyAnswerCount != 0)
        {
            tipsNotCompleted.SetActive(true);
            Invoke("GameNotCompleted", 2f);
        }

    }

    void GameWin()
    {
        tipsCorrectly.SetActive(false);
        canvasSyntesisGame.SetActive(false);
    }

    void GameLose()
    {
        tipsUncorrectly.SetActive(false);

    }
    
    void GameNotCompleted()
    {
        tipsNotCompleted.SetActive(false);
    }
}

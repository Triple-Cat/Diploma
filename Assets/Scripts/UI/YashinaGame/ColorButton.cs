using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] LevelSyntasis levelSyntasis;
    [SerializeField] MoveColorButton[] moveColorButton;

    [SerializeField] int amountColorButton;

    [SerializeField] public GameObject chooseSpells;

    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject tipsUncorrectly;

    [SerializeField] private int correctlyAnswerCount;
    [SerializeField] private int amountNededCorrectlyAnswer;

    [SerializeField] Button buttonInteractable;

    public void CheckAnswer()
    {

        —ounting—orrectlyAnswerCount();

        if (correctlyAnswerCount == amountNededCorrectlyAnswer)
        {
            buttonInteractable.interactable = false;
            levelSyntasis.GameLevelIncrease();
            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }
        else
        {
            buttonInteractable.interactable = false;
            correctlyAnswerCount = 0;
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
    }

    void GameWin()
    {
        tipsCorrectly.SetActive(false);
        buttonInteractable.interactable = true;
        levelSyntasis.ActivateGameLevel();
    }

    void GameLose()
    {
        UnPressedButton();
        MoveButton();
        buttonInteractable.interactable = true;
        tipsUncorrectly.SetActive(false);
    }

    private void —ounting—orrectlyAnswerCount()
    {
        for (int i = 0; i < amountColorButton; i++)
        {
            correctlyAnswerCount += moveColorButton[i].buttonPrice;
        }
    }

    private void MoveButton()
    {
        for (int i = 0; i < amountColorButton; i++)
        {
            moveColorButton[i].ButtonMove();
        }
    }
    private void UnPressedButton()
    {
        for (int i = 0; i < amountColorButton; i++)
        {
            moveColorButton[i].isPressed = false;
            moveColorButton[i].buttonPrice = 0;
            moveColorButton[i].ButtonScaleDecrease();
        }
    }
}

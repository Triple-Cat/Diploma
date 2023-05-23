using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaesarGameScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI userText;
    [SerializeField] string[] cipherText;
    [SerializeField] int currentText;
    [SerializeField] string userCurrentText;
    [SerializeField] LevelSyntasis levelSyntasis;


    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject tipsUncorrectly;

    [SerializeField] GameObject attackButtons;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;

    [SerializeField] Button buttonInteractable;


    void Awake()
    {
        userText.text = cipherText[currentText];
        attackButtons.SetActive(false);
    }

    void Update()
    {
        if (userText.text == userCurrentText)
        {
            attackButtons.SetActive(true);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
    }
    
    public void RightUserText()
    {
        if (currentText < 18)
        {
            userText.text = cipherText[currentText++];
        }

    }
    public void LeftUserText()
    {
        if (currentText > 1)
        {
            userText.text = cipherText[currentText--];
        }
    } 

    public void GameWin()
    {
        tipsCorrectly.SetActive(false);

        levelSyntasis.GameLevelIncrease();
        levelSyntasis.ActivateGameLevel();
    }

    void GameLose()
    {
        tipsUncorrectly.SetActive(false);
    }

    public void AttackRightButton()
    {
        if (userCurrentText == "Cлабость к атакам справа")
        {
            buttonInteractable.interactable = false;

            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }

        else
        {
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
    }
    public void AttackCenterButton()
    {
        if (userCurrentText == "Cлабость к атакам по центру")
        {
            buttonInteractable.interactable = false;
            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }

        else
        {
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
    }
    public void AttackLeftButton()
    {
        if (userCurrentText == "Cлабость к атакам слева")
        {
            buttonInteractable.interactable = false;

            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }

        else
        {
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
    }
}

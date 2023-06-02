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
    [SerializeField] Button buttonInteractable1;
    [SerializeField] Button buttonInteractable2;



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
    public void PressedButton()
    {
        buttonInteractable.interactable = false;
        buttonInteractable1.interactable = false;
        buttonInteractable2.interactable = false;
        Invoke("UnPressedButton", 3f);

    }
    public void UnPressedButton()
    {
        buttonInteractable.interactable = true;
        buttonInteractable1.interactable = true;
        buttonInteractable2.interactable = true;
    }

    public void AttackRightButton()
    {
        if (userCurrentText == "Атака справа")
        {
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
        if (userCurrentText == "Атака по центру")
        {
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
        if (userCurrentText == "Атака слева")
        {
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

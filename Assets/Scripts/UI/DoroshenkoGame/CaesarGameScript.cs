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

    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;
    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasControl;

    [SerializeReference] GameObject canvasSyntesisGame;
    [SerializeField] public GameObject chooseSpells;

    // Start is called before the first frame update
    void Awake()
    {
        userText.text = cipherText[currentText];
    }

    // Update is called once per frame
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
    
    public void InitializeCipherTextRight()
    {
        cipherText[0] = "��������� ������������";
        cipherText[1] = "��������� ������������";
        cipherText[2] = "��������� �����������";
        cipherText[3] = "��������� ������������";
        cipherText[4] = "��������� ������������";
        cipherText[5] = "��������� ������������";
        cipherText[6] = "��������� ������������";
        cipherText[7] = "��������� ������������";
        cipherText[8] = "ȸ������� �����������";
        cipherText[9] = "��������� �����������";
    }
    public void InitializeCipherTextLeft()
    {
        cipherText[0] = "��������� ������������";
        cipherText[1] = "�������� ������������";
        cipherText[2] = "��������� �����������";
        cipherText[3] = "ȸ������� �����������";
        cipherText[4] = "��������� ������������";
        cipherText[5] = "��������� ������������";
        cipherText[6] = "��������� ������������";
        cipherText[7] = "��������� ������������";
        cipherText[8] = "��������� ������������";
        cipherText[9] = "��������� ������������";
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
        if(currentText > 1)
        {
            userText.text = cipherText[currentText--];
        }
    }

    public void CheckAnswer()
    {
        if (userText.text == "��������� ������������")
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

    public void GameWin()
    {
        tipsCorrectly.SetActive(false);
        canvasSyntesisGame.SetActive(false);
        chooseSpells.SetActive(true);
        BeforeDialogueObject.SetActive(false);
        AfterDialogueObject.SetActive(true);
    }

    void GameLose()
    {
        tipsUncorrectly.SetActive(false);
        BeforeDialogueObject.SetActive(false);
        AfterDialogueObject.SetActive(true);
    }
}

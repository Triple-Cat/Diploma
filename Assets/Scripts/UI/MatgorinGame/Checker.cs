using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public int sumAnswer;
    public int needSumAnswer;

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasControl;
    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;

    public void Result()
    {
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
        tipsUncorrectly.SetActive(false);
    }
    private void InvTipsCorrectly()
    {
        tipsCorrectly.SetActive(false);
        canvasMiniGame.SetActive(false);
        canvasControl.SetActive(true);
        BeforeDialogueObject.SetActive(false);
        AfterDialogueObject.SetActive(true);
    }
}

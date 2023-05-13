using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public int sumAnswer;

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasConrtrol;

    public void Result()
    {
        if (sumAnswer == 4)
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
        canvasConrtrol.SetActive(true);
    }
}

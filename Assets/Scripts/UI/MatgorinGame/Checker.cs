using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public int sumAnswer;

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;

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
            Invoke("InvTipsSWOTBar", 2f);
        }
    }

    private void InvTipsSWOTBar()
    {
        tipsUncorrectly.SetActive(false);
    }
    private void InvTipsCorrectly()
    {
        tipsCorrectly.SetActive(false);
    }
}

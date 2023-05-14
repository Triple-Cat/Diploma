using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIElementOverlap : MonoBehaviour
{
    [SerializeField] Checker checker;
    [SerializeField] string barTag;
    [SerializeField] int needPointsToComplete;

    public int currentCountBar;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == barTag)
        {
            currentCountBar++;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == barTag)
        {
            currentCountBar--;
        }
    }

    public void AnswerCheck()
    {       
        if (currentCountBar == needPointsToComplete)
        {
            checker.sumAnswer++;
        }
        else
        {
            checker.sumAnswer = 0;
        }
    }

}

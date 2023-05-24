using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCyclic : MonoBehaviour
{
    [SerializeField] LevelSyntasis levelSyntasis;

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;

    private UIItem currentElement;
    [SerializeField] string barTag;
    [SerializeField] int needPointsToComplete;

    public int currentCountBar;


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        var uIItem = collider2D.gameObject.GetComponent<UIItem>();
        currentElement = uIItem;
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
            tipsCorrectly.SetActive(true);
            Invoke("InvTipsCorrectly", 2f);
            levelSyntasis.GameLevelIncrease();
            levelSyntasis.ActivateGameLevel();
        }
        else
        {
            tipsUncorrectly.SetActive(true);
            currentElement.MoveToInitPos();
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
    }

}

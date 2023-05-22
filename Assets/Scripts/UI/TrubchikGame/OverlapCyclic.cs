using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCyclic : MonoBehaviour
{

    [SerializeField] GameObject tipsUncorrectly;
    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject canvasMiniGame;
    [SerializeField] GameObject canvasControl;
    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;


    private UIItem currentElement;
    [SerializeField] string barTag;
    [SerializeField] int needPointsToComplete;

    public int currentCountBar;

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

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        var uIItem = collider2D.gameObject.GetComponent<UIItem>();
        currentElement = uIItem;
        Debug.Log(currentElement);
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
        canvasMiniGame.SetActive(false);
        canvasControl.SetActive(true);
        BeforeDialogueObject.SetActive(false);
        AfterDialogueObject.SetActive(true);
    }

}

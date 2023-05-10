using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIElementOverlap : MonoBehaviour
{
    public UIItem[] uIItem;

    public GameObject tipsUncorrectly;
    public GameObject tipsCorrectly;

    [SerializeField] string barTag;
    public int currentIndexBar;

    [SerializeField] Collider2D currentBar;
    [SerializeField] private int barIndex;
    [SerializeField] private int barCount;

    public int currentCountBar;

    private void Start()
    {
        currentBar = gameObject.GetComponent<Collider2D>(); 
    }

    private void Update()
    {
    }

    private void CheckOverlap(Transform parent)
    {
        int childCount = parent.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Collider2D childCollider = parent.GetChild(i).GetComponent<Collider2D>();

            if (childCollider != null && currentBar.bounds.Intersects(childCollider.bounds))
            {
                currentCountBar++;
            }

            CheckOverlap(parent.GetChild(i));
        }
    }


    public void GetAnswerForCharactertisticBar()
    {
        CheckOverlap(currentBar.transform);

       
        CheckAnswerForOverlap();
    }

    private void CheckAnswerForOverlap()
    {

        GetAnswer();
    }

    private void GetAnswer()
    {
        if (true)
        {
            tipsUncorrectly.SetActive(true);
            Invoke("InvTipsSWOTBar", 2f);
        }  
        else
        {
            tipsCorrectly.SetActive(true);
            Invoke("InvTipsCorrectly", 2f);
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

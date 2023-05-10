using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUIElementOverlap : MonoBehaviour
{
    public UIItem uIItem;

    public GameObject tipsCharacteristicBar;
    public GameObject tipsSWOTBar;
    public GameObject tipsCorrectly;
    public GameObject miniGameSWOT;
    public GameObject chooseSpells;

    public Collider2D characteristicBar;
    [SerializeField] private int CBarIndex = 0;
    [SerializeField] private int characteristicBarCount = 0;

    public Collider2D SBar;
    [SerializeField] private int SBarIndex = 1;
    [SerializeField] private int SBarCount = 0;
    private int SBar—orrectWord = 3;

    public Collider2D WBar;
    [SerializeField] private int WBarIndex = 2;
    [SerializeField] private int WBarCount = 0;
    private int WBar—orrectWord = 2;

    public Collider2D OBar;
    [SerializeField] private int OBarIndex = 3;
    [SerializeField] private int OBarCount = 0;
    private int OBar—orrectWord = 2;

    public Collider2D TBar;
    [SerializeField] private int TBarIndex = 4;
    [SerializeField] private int TBarCount = 0;
    private int TBar—orrectWord = 1;

    public int currentCountBar;

    private void Start()
    {

    }

    private void Update()
    {
    }

    private int CheckOverlap(Transform parent, int countChild/*, int currentIndexBar*/)
    {
        int childCount = parent.childCount;
        currentCountBar = countChild;
        for (int i = 0; i < childCount; i++)
        {
            Collider2D childCollider = parent.GetChild(i).GetComponent<Collider2D>();
            if (childCollider != null && childCollider.bounds.Intersects(childCollider.bounds))
            {
               //Debug.Log(currentIndexBar);
               currentCountBar++;
            }
            CheckOverlap(parent.GetChild(i), currentCountBar/*, currentIndexBar*/);
        }
        countChild = currentCountBar;
        return countChild;
    }

    public void GetAnswerForCharactertisticBar()
    {
        characteristicBarCount = CheckOverlap(characteristicBar.transform, 0/*, uIItem.indexSwotBar*/);
        if (characteristicBarCount != 0)
        {
            tipsCharacteristicBar.SetActive(true);
            Invoke("InvTipsCharacteristicBar", 2f);
        }
        else
            CheckAnswerForOverlap();
    }

    private void CheckAnswerForOverlap()
    {
        SBarCount = CheckOverlap(SBar.transform, 0/*, SBarIndex*/);
        WBarCount = CheckOverlap(WBar.transform, 0/*, WBarIndex*/);
        OBarCount = CheckOverlap(OBar.transform, 0/*, OBarIndex*/);
        TBarCount = CheckOverlap(TBar.transform, 0/*, TBarIndex*/);
        GetAnswer();
    }

    private void GetAnswer()
    {
        if ((SBar—orrectWord != SBarCount) || (WBar—orrectWord != WBarCount) || (OBar—orrectWord != OBarCount) || (TBar—orrectWord != TBarCount))
        {
            tipsSWOTBar.SetActive(true);
            Invoke("InvTipsSWOTBar", 2f);
        }
        else 
        {
            tipsCorrectly.SetActive(true);
            Invoke("InvTipsCorrectly", 2f);
        }
    }
 
    private void InvTipsCharacteristicBar()
    {
        tipsCharacteristicBar.SetActive(false);
    }
    private void InvTipsSWOTBar()
    {
        tipsSWOTBar.SetActive(false);
    }
    private void InvTipsCorrectly()
    {
        tipsCorrectly.SetActive(false);
        miniGameSWOT.SetActive(false);
        chooseSpells.SetActive(true);
    }


}

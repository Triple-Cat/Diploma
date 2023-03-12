using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public bool cardType;
    [SerializeField] public Image image;

    public int squareScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void OnPointerDown(PointerEventData ped)
    { 
        // �� �������� ��� ����� ����� �������� ���������� ������� ���
        if (cardType)
        {
            image.enabled = false;
            squareScore += 1;
            Debug.Log("CardSelection ������ �� �������� " + squareScore);

        }
        else
        {
            squareScore -= 1;
            Debug.Log("CardSelection ������ �� �������� " + squareScore);

        }
 
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
    
    public virtual void OnDrag(PointerEventData ped)
    {

    }

    public void CallSquareMiniGame() 
    { 

    }
}

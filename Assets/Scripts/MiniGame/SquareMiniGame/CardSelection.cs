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

    public virtual void OnPointerDown(PointerEventData ped)
    { 
        // Не работает Ему важно какая картинка нажимается сколько раз
        if (cardType)
        {
            image.enabled = false;
            squareScore += 1;
            Debug.Log("CardSelection Скрипт до передачи " + squareScore);

        }
        else
        {
            squareScore -= 1;
            Debug.Log("CardSelection Скрипт до передачи " + squareScore);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool isContain = false;


    //OnDropRaycast 
    public void OnDrop(PointerEventData eventData)
    {
        CheckChild();

        var otherItemTransform = eventData.pointerDrag.transform;
        if (!isContain)
        {
            otherItemTransform.SetParent(transform);
        }
        else if (isContain)
        {
            otherItemTransform.localPosition = Vector3.zero;
        }
        
    }


    public void CheckChild()
    {
        if (this.transform.childCount == 0)
        {
            isContain = false;
        }
        else if (this.transform.childCount != 0)
        {
            isContain = true;
        }
    }
}

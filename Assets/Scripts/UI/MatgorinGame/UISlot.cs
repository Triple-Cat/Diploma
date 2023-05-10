using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    private bool isContain = false;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        if (!isContain)
        {
            otherItemTransform.SetParent(transform);
            isContain = true;
        }
        else if (isContain)
        {
            otherItemTransform.localPosition = Vector3.zero;
            isContain = false;
        }
    }
}

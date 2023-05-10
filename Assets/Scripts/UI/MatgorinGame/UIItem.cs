using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] CheckUIElementOverlap checkUIElementOverlap;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private RectTransform m_RectTransform;
    [SerializeField] public int indexSwotBar;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        m_RectTransform = GetComponent<RectTransform>();
        m_canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = m_RectTransform.parent;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        
        _canvasGroup.blocksRaycasts = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //[SerializeField] CheckUIElementOverlap checkUIElementOverlap;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private RectTransform m_RectTransform;

    [SerializeField] private int m_IndexNumber;
    [SerializeField] Vector3 InitPosition;
    [SerializeField] Transform InitParent;

    private void Start()
    {

        InitPosition = transform.position;
        InitParent = transform.parent;

        _canvasGroup = GetComponent<CanvasGroup>();
        m_RectTransform = GetComponent<RectTransform>();
        m_canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = m_RectTransform.parent;
        var parentForLayout = slotTransform.parent;
        parentForLayout.SetAsLastSibling();
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

    public void MoveToInitPos()
    {
        transform.SetParent(InitParent);
        transform.position = InitPosition;

    }
}

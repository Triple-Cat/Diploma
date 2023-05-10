using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveColorButton : MonoBehaviour
{
    [SerializeField] private int m_IndexNumber;
    [SerializeField] public int buttonPrice;
    [SerializeField] public bool isPressed = false;
    [SerializeField] public bool isCorrectlyButton;
    [SerializeField] RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ButtonMove();
    }

    public void ButtonPressed()
    {
        if (!isPressed)
        {
            isPressed = true;
            ButtonScaleIncrease();

            if (isCorrectlyButton)
            {
                buttonPrice++;
            }

            else
                buttonPrice--;
        }

        else if (isPressed)
        {
            isPressed = false;
            ButtonScaleDecrease();

            if (isCorrectlyButton)
                buttonPrice--;
            else
                buttonPrice++;
        }
    }

    public void ButtonScaleIncrease()
    {
        rectTransform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void ButtonScaleDecrease()
    {
        rectTransform.localScale = new Vector2(1, 1);
    }

    public void ButtonMove()
    {
        m_IndexNumber = Random.Range(0, 100);
        transform.SetSiblingIndex(m_IndexNumber);
    }
}

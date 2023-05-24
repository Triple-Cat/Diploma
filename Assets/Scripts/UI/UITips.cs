using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITips : MonoBehaviour
{
    [SerializeField] GameObject helpText;
    bool isHelpText = false;

    public void ActivateHelpText()
    {
        if (isHelpText)
        {
            helpText.SetActive(false);
            isHelpText = false;
        }
        else
        {
            helpText.SetActive(true);
            isHelpText = true;
        }
    }
}

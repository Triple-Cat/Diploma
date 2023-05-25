using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] canvasGameObject;
    [SerializeField] GameObject canvasForControl;
    [SerializeField] int allCanvas;
    [SerializeField] int currentCanvas;

    private void Update()
    {
        DeactivForControl();
    }
    void Start()
    {
        DeactivCanvas();
    }

    void DeactivCanvas()
    {
        for (currentCanvas = 0; currentCanvas < allCanvas; currentCanvas++)
        {
            canvasGameObject[currentCanvas].active = false;
        }
    }

    void DeactivForControl()
    {
        currentCanvas = 0;
        for (currentCanvas = 0; currentCanvas < allCanvas; currentCanvas++)
        {
            if (canvasGameObject[currentCanvas].active == true)
            {
                canvasForControl.SetActive(false);
            }
        }
    }
}

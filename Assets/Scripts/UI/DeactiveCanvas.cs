using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] canvasGameObject;
    [SerializeField] int allCanvas;
    [SerializeField] int currentCanvas;
    void Start()
    {
        for(currentCanvas = 0; currentCanvas < allCanvas; currentCanvas++)
        {
            canvasGameObject[currentCanvas].active = false;
        }
    }
}

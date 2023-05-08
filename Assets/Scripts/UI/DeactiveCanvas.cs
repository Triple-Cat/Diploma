using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] canvasGameObject;
    [SerializeField] int allCanvas;
    [SerializeField] int currentCanvas;
    // Start is called before the first frame update
    void Start()
    {
        for(currentCanvas = 0; currentCanvas < allCanvas; currentCanvas++)
        {
            canvasGameObject[currentCanvas].active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

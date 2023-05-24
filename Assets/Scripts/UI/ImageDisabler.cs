using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDisabler : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private GameObject ImageForMiniGame;

    void Update()
    {
        if (DialogueBox == true)
        {
            ImageForMiniGame.SetActive(false);
        }
    }
}

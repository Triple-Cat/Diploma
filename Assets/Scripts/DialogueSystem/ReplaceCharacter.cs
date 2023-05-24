using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceCharacter : MonoBehaviour
{
    [SerializeField] GameObject BeforeDialogueObject;
    [SerializeField] GameObject AfterDialogueObject;

    public void Replace()
    {
        BeforeDialogueObject.SetActive(false);
        AfterDialogueObject.SetActive(true);
    }
}

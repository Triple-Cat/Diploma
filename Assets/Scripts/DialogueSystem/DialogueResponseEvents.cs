using UnityEngine;
using System;

public class DialogueResponseEvents : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private ResponseEvent[] events;
    [SerializeField] private GameObject MiniGame;
    [SerializeField] private GameObject CanvasControl;
    [SerializeField] private GameObject ImageForMiniGame;

    public DialogueObject DialogueObject => dialogueObject;

    public ResponseEvent[] Events => events;

    public void OnValidate()
    {
        if (dialogueObject == null) return;
        if (dialogueObject.Responses == null) return;
        if (events != null && events.Length == dialogueObject.Responses.Length) return;

        if (events == null)
        {
            events = new ResponseEvent[dialogueObject.Responses.Length];
        }
        else
        {
            Array.Resize(ref events, dialogueObject.Responses.Length);
        }

        for (int i = 0; i < dialogueObject.Responses.Length; i++)
        {
            Response response = dialogueObject.Responses[i];

            if (events[i] != null)
            {
                events[i].name = response.ResponseText;
                continue;
            }
            events[i] = new ResponseEvent() { name = response.ResponseText };
        }
    }
    public void MiniGameActivator(GameObject gameObject)
    {
        this.MiniGame = gameObject;
        gameObject.SetActive(true);
    }
    public void CanvasControlDisabler(GameObject gameObject)
    {
        this.CanvasControl = gameObject;
        gameObject.SetActive(false);
    }
    
    public void ImageActivator(GameObject gameObject)
    {
        this.ImageForMiniGame = gameObject;
        gameObject.SetActive(true);
    }
}

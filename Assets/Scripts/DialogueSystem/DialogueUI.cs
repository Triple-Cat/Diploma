using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textlabel;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject CanvasForControl;
    [SerializeField] private GameObject SkipButton;

    public bool isOpen { get; private set; }
    public bool isPressed = false;

    private ResponseHandler responseHandler;
    private TypeWriterEffect typeWriterEffect;
    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        CanvasForControl.SetActive(false);
        SkipButton.SetActive(true);
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvent(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);
            textlabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitForSeconds(1);
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }
    
    
    private IEnumerator RunTypingEffect(string dialogue)
    {
        typeWriterEffect.Run(dialogue, textlabel);
        while (typeWriterEffect.isRunning)
        {
            yield return null;

       
        }
    }

    public void SkipTyping()
    {
        typeWriterEffect.Stop();
    }
    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        SkipButton.SetActive(false);
        textlabel.text = string.Empty;
        CanvasForControl.SetActive(true);
    }
    public void PressTheButton()
    {
        isPressed = true;
    }
}

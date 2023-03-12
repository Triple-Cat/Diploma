using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&other.TryGetComponent(out CustomCharacterController player))
        {
            player.Interactable = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out CustomCharacterController player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator&&dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
    public void Interact(CustomCharacterController player)
    {
       foreach(DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                player.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }


        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}

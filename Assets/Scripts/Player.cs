using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    private const float MoveSpeed = 10f;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (dialogueUI.isOpen) return;
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        rb.MovePosition(rb.position + input.normalized * (MoveSpeed * Time.fixedDeltaTime));

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
    }
}

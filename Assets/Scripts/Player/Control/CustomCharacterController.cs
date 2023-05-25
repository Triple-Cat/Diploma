using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomCharacterController : MonoBehaviour
{
    public Rigidbody rig; // Ссылка на ригидбоди
    public Transform mainCamera; // Ссылка на камеру
    public float walkingSpeed = 2f; // Скорость передвижения
    public float runningSpeed = 6f; // Скорость бега
    public float currentSpeed; // Текущая скорость
    private float animationInterpolation = 1f;
    public FixedJoystick fixJoy; // Ссылка на джостик
    private Vector3 moveVector; //Направление движения персонажа 
    public float horizontal;
    public float vertical;
    public float lerpMultiplier = 7;

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }


    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
   
        moveVector.x = horizontal * runningSpeed; 
        moveVector.y = vertical * runningSpeed; 

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }

    void Walk()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);


        moveVector.x = horizontal * walkingSpeed; 
        moveVector.y = vertical * walkingSpeed; 

        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }

    private void Update()
    {
        horizontal = Mathf.Lerp(horizontal, fixJoy.Horizontal, Time.deltaTime * lerpMultiplier);
        vertical = Mathf.Lerp(vertical, fixJoy.Vertical, Time.deltaTime * lerpMultiplier);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Walk();
            }
            else
            {
                Run();
            }
        }
        else
        {
            Walk();
        }

        if (dialogueUI.isOpen) return;
     
    }

    public void DialogueStart()
    {
        if (Interactable != null)
        {
            Interactable.Interact(this);
        }
    }

    void FixedUpdate()
    {

        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;

        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;

        movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horizontal * currentSpeed, currentSpeed);
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        rig.angularVelocity = Vector3.zero;
    }
}

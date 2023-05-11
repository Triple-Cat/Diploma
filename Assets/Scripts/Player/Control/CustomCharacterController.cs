using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomCharacterController : MonoBehaviour
{
    //public Animator anim;
    public Rigidbody rig; // ������ �� ���������
    public Transform mainCamera; // ������ �� ������
    public float jumpForce = 3.5f; // ���� ������
    public float walkingSpeed = 2f; // �������� ������������
    public float runningSpeed = 6f; // �������� ����
    public float currentSpeed; // ������� ��������
    private float animationInterpolation = 1f;
    public FixedJoystick fixJoy; // ������ �� �������
    private Vector3 moveVector; //����������� �������� ��������� 
    public float horizontal;
    public float vertical;
    public float lerpMultiplier = 7;

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        //// ����������� ������ � �������� ������
        //Cursor.lockState = CursorLockMode.Locked;
        //// � ������ ��� ���������
        //Cursor.visible = false;
    }

    //������ ����
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);

        //moveVector.x = Input.GetAxis("Horizontal") * runningSpeed; // ���������� � �� 
        //moveVector.y = Input.GetAxis("Vertical") * runningSpeed; // ���������� � �� 

        moveVector.x = horizontal * runningSpeed; // ���������� � ��������
        moveVector.y = vertical * runningSpeed; // ���������� � ��������

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }

    //������ ������
    void Walk()
    {
        // Mathf.Lerp - ������� �� ��, ����� ������ ���� ����� animationInterpolation(� ������ ������) ������������ � ����� 1 �� ��������� Time.deltaTime * 3.
        // Time.deltaTime - ��� ����� ����� ���� ������ � ���������� ������. ��� ��������� ������ ���������� � ������ ����� �� ������� ���������� �� ������ � ������� (FPS)!!!
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);

        //moveVector.x = Input.GetAxis("Horizontal") * walkingSpeed; // ���������� � �� 
        //moveVector.y = Input.GetAxis("Vertical") * walkingSpeed; // ���������� � �� 

        moveVector.x = horizontal * walkingSpeed; // ���������� � ��������
        moveVector.y = vertical * walkingSpeed; // ���������� � ��������

        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }

    private void Update()
    {
        horizontal = Mathf.Lerp(horizontal, fixJoy.Horizontal, Time.deltaTime * lerpMultiplier);
        vertical = Mathf.Lerp(vertical, fixJoy.Vertical, Time.deltaTime * lerpMultiplier);
        // ������������� ������� ��������� ����� ������ �������������� 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // ������ �� ������ W � Shift?
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            // ������ �� ��� ������ A S D?
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // ���� ��, �� �� ���� ������
                Walk();
            }
            // ���� ���, �� ����� �����!
            else
            {
                Run();
            }
        }
        // ���� W & Shift �� ������, �� �� ������ ���� ������
        else
        {
            Walk();
        }
        //���� ����� ������, �� � ��������� ���������� ��������� �������, ������� ���������� �������� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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

    // Update is called once per frame
    void FixedUpdate()
    {
        // ����� �� ������ �������� ��������� � ����������� �� ����������� � ������� ������� ������
        // ��������� ����������� ������ � ������ �� ������ 
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        // ����� ����������� ������ � ������ �� �������� �� ���� ������� �� ������ ����� ��� ����, ����� ����� �� ������� ������, �������� ����� ���� ������� ��� ����� ������� ����� ��� ����
        // ������ ���� ��������� ��� ����� ����� camF.y = 0 � camR.y = 0 :)
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        // ��� �� �������� ���� ������� �� ������ W & S �� ����������� ������ ������ � ���������� � �������� �� ������ A & D � �������� �� ����������� ������ ������
        //movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed); //PC

        movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horizontal * currentSpeed, currentSpeed);

        // Magnitude - ��� ������ �������. � ���� ������ �� currentSpeed ��� ��� �� �������� ���� ������ �� currentSpeed �� 86 ������. � ���� �������� ����� �������� 1.
        //anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        // ����� �� ������� ���������! ������������� �������� ������ �� x & z ������ ��� �� �� ����� ����� ��� �������� ������� � ������
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        // � ���� ��� ���, ��� �������� �������� �� ����� � ��� �������� � ������� ���� ������
        rig.angularVelocity = Vector3.zero;
    }


    //������ ������
    public void Jump()
    {
        // ��������� ������ �� ������� ��������.
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}

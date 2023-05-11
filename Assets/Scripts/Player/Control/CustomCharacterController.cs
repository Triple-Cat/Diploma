using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomCharacterController : MonoBehaviour
{
    //public Animator anim;
    public Rigidbody rig; // Ссылка на ригидбоди
    public Transform mainCamera; // Ссылка на камеру
    public float jumpForce = 3.5f; // Сила прыжка
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


    // Start is called before the first frame update
    void Start()
    {
        //// Прекрепляем курсор к середине экрана
        //Cursor.lockState = CursorLockMode.Locked;
        //// и делаем его невидимым
        //Cursor.visible = false;
    }

    //Скрипт бега
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);

        //moveVector.x = Input.GetAxis("Horizontal") * runningSpeed; // управление с пк 
        //moveVector.y = Input.GetAxis("Vertical") * runningSpeed; // управление с пк 

        moveVector.x = horizontal * runningSpeed; // управление с телефона
        moveVector.y = vertical * runningSpeed; // управление с телефона

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }

    //Скрипт ходьбы
    void Walk()
    {
        // Mathf.Lerp - отвчает за то, чтобы каждый кадр число animationInterpolation(в данном случае) приближалось к числу 1 со скоростью Time.deltaTime * 3.
        // Time.deltaTime - это время между этим кадром и предыдущим кадром. Это позволяет плавно переходить с одного числа до второго НЕЗАВИСИМО ОТ КАДРОВ В СЕКУНДУ (FPS)!!!
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);

        //moveVector.x = Input.GetAxis("Horizontal") * walkingSpeed; // управление с пк 
        //moveVector.y = Input.GetAxis("Vertical") * walkingSpeed; // управление с пк 

        moveVector.x = horizontal * walkingSpeed; // управление с телефона
        moveVector.y = vertical * walkingSpeed; // управление с телефона

        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }

    private void Update()
    {
        horizontal = Mathf.Lerp(horizontal, fixJoy.Horizontal, Time.deltaTime * lerpMultiplier);
        vertical = Mathf.Lerp(vertical, fixJoy.Vertical, Time.deltaTime * lerpMultiplier);
        // Устанавливаем поворот персонажа когда камера поворачивается 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // Зажаты ли кнопки W и Shift?
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            // Зажаты ли еще кнопки A S D?
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                // Если да, то мы идем пешком
                Walk();
            }
            // Если нет, то тогда бежим!
            else
            {
                Run();
            }
        }
        // Если W & Shift не зажаты, то мы просто идем пешком
        else
        {
            Walk();
        }
        //Если зажат пробел, то в аниматоре отправляем сообщение тригеру, который активирует анимацию прыжка
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
        // Здесь мы задаем движение персонажа в зависимости от направления в которое смотрит камера
        // Сохраняем направление вперед и вправо от камеры 
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        // Чтобы направления вперед и вправо не зависили от того смотрит ли камера вверх или вниз, иначе когда мы смотрим вперед, персонаж будет идти быстрее чем когда смотрит вверх или вниз
        // Можете сами проверить что будет убрав camF.y = 0 и camR.y = 0 :)
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        // Тут мы умножаем наше нажатие на кнопки W & S на направление камеры вперед и прибавляем к нажатиям на кнопки A & D и умножаем на направление камеры вправо
        //movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed); //PC

        movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horizontal * currentSpeed, currentSpeed);

        // Magnitude - это длинна вектора. я делю длинну на currentSpeed так как мы умножаем этот вектор на currentSpeed на 86 строке. Я хочу получить число максимум 1.
        //anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        // Здесь мы двигаем персонажа! Устанавливаем движение только по x & z потому что мы не хотим чтобы наш персонаж взлетал в воздух
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        // У меня был баг, что персонаж крутился на месте и это исправил с помощью этой строки
        rig.angularVelocity = Vector3.zero;
    }


    //Скрипт прыжка
    public void Jump()
    {
        // Выполняем прыжок по команде анимации.
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}

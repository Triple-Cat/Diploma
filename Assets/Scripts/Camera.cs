using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float MouseX;
    float MouseY;
    float sensivityMouse = 200f;
    public Transform Player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;
        Player.Rotate(MouseX * new Vector3(0,1,0));
        transform.Rotate(-MouseY * new Vector3(1,0,0));
    }
}

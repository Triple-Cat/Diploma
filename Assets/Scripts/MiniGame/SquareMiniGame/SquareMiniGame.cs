using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareMiniGame : MonoBehaviour
{

    [SerializeField] private Image rotationPanel; // ������ �� ������ ���������� ��������� ���������
    [SerializeField] private Behaviour canvasMiniGame; // ������ �� ������ � ���� ����� 
    [SerializeField] private GameObject SquareGameRunner; // ������ �� ������ � ���������� ��������
    [SerializeField] private Text scoreText; // ������ �� ����� � ������
    [SerializeField] private Text taskText; // ������ �� ����� � ��������
    [SerializeField] private Image joystick1; // ������ �� �������
    [SerializeField] private Image joystick2; // ������ �� �������


    public int scoreSquareGame = 0; // ���� ���� ���� ����

    public int winPointSquareGame;
    public bool squareGameIsWin = false;

    public void Start()
    {
        canvasMiniGame.enabled = false;
    }

    public void Update()
    {
        // ����� ������ ������������ ���� ����
        if (SquareGameRunner.activeInHierarchy)
            if (winPointSquareGame < 3)
        {
            SquareGame();
        }
        // ����� ������ ������������� ������ � ����� ����
        else if (winPointSquareGame == 3)
        {
            MiniGameIsWin();
        }


        // ������������� ���� �� ������� �� ������ 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            canvasMiniGame.enabled = false;
        } 



        //scoreText.text = "����:" + scoreSquareGame;


    }

    public void SquareGame()
    {

        canvasMiniGame.enabled = true; // �������� ������ � ���� ����� 
        Time.timeScale = 0; // ������������� �����  
        
        rotationPanel.enabled = false; // ��������� ������ ���������� �� ������� �� �������

        // ����������� ������ � �������� ������
        Cursor.lockState = CursorLockMode.None;
        // � ������ ��� ���������
        Cursor.visible = true;
        joystick1.enabled = false;
        joystick2.enabled = false;
    }

    public void ScoreIncrease()
    {
        scoreSquareGame++;
    }

    public void ScoreReduce()
    {
        scoreSquareGame--;
    }

    public void PointSquareGame()
    {
        winPointSquareGame++;
    }

    public void MiniGameIsWin()
    {
        squareGameIsWin = true;
        Time.timeScale = 1;
        canvasMiniGame.enabled = false;
        joystick1.enabled = true;
        joystick2.enabled = true;
        rotationPanel.enabled = true;
    }
}

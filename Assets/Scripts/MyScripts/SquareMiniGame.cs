using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareMiniGame : MonoBehaviour
{

    [SerializeField] public Image panel; // ������ �� ������
    [SerializeField] public Behaviour canvas; // ������ �� ������ 
    [SerializeField] public Text scoreText; // ������ �� ����� � ������
    [SerializeField] public Text taskText; // ������ �� ����� � ��������

    public int scoreSquareGame = 0; // ���� ���� ���� ����

    public int winPointSquareGame;
    public bool squareGameIsWin = false;

    public void Start()
    {
        canvas.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SquareGame();         
        }  

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
        scoreText.text = "����:" + scoreSquareGame;

        if (winPointSquareGame == 3)
        {
            MiniGameIsWin();
        }
    }

    public void SquareGame()
    {

        canvas.enabled = true; // �������� ������ � ���� ����� 
        Time.timeScale = 0; // ������������� �����  
        
        panel.enabled = false; // ��������� ������ ���������� �� ������� �� �������

        // ����������� ������ � �������� ������
        Cursor.lockState = CursorLockMode.None;
        // � ������ ��� ���������
        Cursor.visible = true;

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
        canvas.enabled = false;
    }
}

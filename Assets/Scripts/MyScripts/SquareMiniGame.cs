using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareMiniGame : MonoBehaviour
{

    [SerializeField] private Image rotationPanel; // Ссылка на панель управление поворотом персонажа
    [SerializeField] private Behaviour canvasMiniGame; // Ссылка на канвас с мини игрой 
    [SerializeField] private GameObject SquareGameRunner; // Ссылка на канвас с диалоговой системой
    [SerializeField] private Text scoreText; // Ссылка на текст с счётом
    [SerializeField] private Text taskText; // Ссылка на текст с заданием
    [SerializeField] private Image joystick1; // Ссылка на джостик
    [SerializeField] private Image joystick2; // Ссылка на джостик


    public int scoreSquareGame = 0; // Счёт этой мини игры

    public int winPointSquareGame;
    public bool squareGameIsWin = false;

    public void Start()
    {
        canvasMiniGame.enabled = false;
    }

    public void Update()
    {
        // Вызов метода запускающего мини игру
        if (SquareGameRunner.activeInHierarchy)
            if (winPointSquareGame < 3)
        {
            SquareGame();
        }
        // Вызов метода присуждающего победу в минин игре
        else if (winPointSquareGame == 3)
        {
            MiniGameIsWin();
        }


        // Возобновление игры по нажатию на кнопку 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            canvasMiniGame.enabled = false;
        } 



        //scoreText.text = "Счёт:" + scoreSquareGame;


    }

    public void SquareGame()
    {

        canvasMiniGame.enabled = true; // Включаем канвас с мини игрой 
        Time.timeScale = 0; // Останавливаем время  
        
        rotationPanel.enabled = false; // Отключаем панель отвечающую за поворот на мобилке

        // Прекрепляем курсор к середине экрана
        Cursor.lockState = CursorLockMode.None;
        // и делаем его невидимым
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquareMiniGame : MonoBehaviour
{

    [SerializeField] public Image panel; // —сылка на панель
    [SerializeField] public Behaviour canvas; // —сылка на канвас 
    [SerializeField] public Text scoreText; // —сылка на текст с счЄтом
    [SerializeField] public Text taskText; // —сылка на текст с заданием

    public int scoreSquareGame = 0; // —чЄт этой мини игры

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
        scoreText.text = "—чЄт:" + scoreSquareGame;

        if (winPointSquareGame == 3)
        {
            MiniGameIsWin();
        }
    }

    public void SquareGame()
    {

        canvas.enabled = true; // ¬ключаем канвас с мини игрой 
        Time.timeScale = 0; // ќстанавливаем врем€  
        
        panel.enabled = false; // ќтключаем панель отвечающую за поворот на мобилке

        // ѕрекрепл€ем курсор к середине экрана
        Cursor.lockState = CursorLockMode.None;
        // и делаем его невидимым
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

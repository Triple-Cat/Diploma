using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataBaseHolder : MonoBehaviour
{
    [SerializeField] public int globalScore;
    [SerializeField] public int characterLevel;
    [SerializeField] public Text globalScoreText; // —сылка на текст с счЄтом

    public SquareMiniGame squareMiniGame = new SquareMiniGame();
    public int winPointSquareMiniGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winPointSquareMiniGame == 3)
        {
            winPointSquareMiniGame++;
            globalScore = squareMiniGame.scoreSquareGame;
            globalScoreText.text += globalScore;
        }


    }
}

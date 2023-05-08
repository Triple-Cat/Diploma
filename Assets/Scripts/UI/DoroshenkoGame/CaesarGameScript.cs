using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaesarGameScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI userText;
    [SerializeField] string[] cipherText;
    [SerializeField] int currentText;

    [SerializeField] GameObject tipsCorrectly;
    [SerializeField] GameObject tipsUncorrectly;

    [SerializeReference] GameObject canvasSyntesisGame;
    [SerializeField] public GameObject chooseSpells;

    // Start is called before the first frame update
    void Awake()
    {
        userText.text = cipherText[currentText];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InitializeCipherTextRight()
    {
        cipherText[0] = "ׁממבשוםטו ןמכüחמגאעוכÿ";
        cipherText[1] = "װססהüחנכח עסמÿךסודץחמג";
        cipherText[2] = "׳פפזÿךףמך ץפסגםפח¸רךסו";
        cipherText[3] = "Úקקיגםצסם רקפונקךטûםפח";
        cipherText[4] = "Ýתתלונשפנ ûתקחףתםכ‏נקך";
        cipherText[5] = "ְ‎‎ןחףüקף ‏‎תךצ‎נמבףתם";
        cipherText[6] = "ֳאאעךצÿתצ בא‎םשאףסהצ‎נ";
        cipherText[7] = "¨דדץםשג‎ש הדאנüדצפזשאף";
        cipherText[8] = "ָ¸¸רנüואü ז¸דףÿ¸שקיüדצ";
        cipherText[9] = "ֻטטûףÿחדÿ יט¸צגטüתלÿ¸ש";
    }
    public void InitializeCipherTextLeft()
    {
        cipherText[0] = "ׁממבשוםטו ןמכüחמגאעוכÿ";
        cipherText[1] = "־ככ‏צגך¸ג לכטשוכÿ‎ןגטü";
        cipherText[2] = "ֻטטûףÿחדÿ יט¸צגטüתלÿ¸ש";
        cipherText[3] = "ָ¸¸רנüואü ז¸דףÿ¸שקיüדצ";
        cipherText[4] = "¨דדץםשג‎ש הדאנüדצפזשאף";
        cipherText[5] = "ֳאאעךצÿתצ בא‎םשאףסהצ‎נ";
        cipherText[6] = "ְ‎‎ןחףüקף ‏‎תךצ‎נמבףתם";
        cipherText[7] = "Ýתתלונשפנ ûתקחףתםכ‏נקך";
        cipherText[8] = "Úקקיגםצסם רקפונקךטûםפח";
        cipherText[9] = "װססהüחנכח עסמÿךסודץחמג";
    }
    public void RightUserText()
    {
        if (currentText < 18)
        {
            userText.text = cipherText[currentText++];
        }

    }
     public void LeftUserText()
    {
        if(currentText > 1)
        {
            userText.text = cipherText[currentText--];
        }
    }

    public void CheckAnswer()
    {
        if (userText.text == "ׁממבשוםטו ןמכüחמגאעוכÿ")
        {
            tipsCorrectly.SetActive(true);
            Invoke("GameWin", 2f);
        }
        else
        {
            tipsUncorrectly.SetActive(true);
            Invoke("GameLose", 2f);
        }
    }

    public void GameWin()
    {
        tipsCorrectly.SetActive(false);
        canvasSyntesisGame.SetActive(false);
        chooseSpells.SetActive(true);
    }

    void GameLose()
    {
        tipsUncorrectly.SetActive(false);
    }
}

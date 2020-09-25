using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public Text remainingTreasures;

    public TreasureManager treasureManager;

    public GameObject resultScreen;

    public Button playAgain;
    public Button backToMenu;

    public Text resultText;

    public EndGame endgame;

    private int currentremainingTreasuresCount;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;

        if( playAgain != null) 
            playAgain.onClick.AddListener(PlayAgainBtnFun);

        if( backToMenu != null) 
            backToMenu.onClick.AddListener(BackToMenuBtnFun);
        
        currentremainingTreasuresCount = treasureManager.AmmountOfTreasures;
        remainingTreasures.text = "Remaining treasures: " + currentremainingTreasuresCount.ToString();
    }

    void Update()
    {
        if(currentremainingTreasuresCount > treasureManager.AmmountOfTreasures){
            currentremainingTreasuresCount = treasureManager.AmmountOfTreasures;
            remainingTreasures.text = "Remaining treasures: " + currentremainingTreasuresCount.ToString();
        }

        if(currentremainingTreasuresCount == 0)
            endgame.isGameWon = true;

        if(endgame.getIsGameFinished())
            ShowResultScreen();   
    }

    void ShowResultScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

        if(endgame.getIsGameWon()){
            resultText.text = "Congratulations\nYou Won!";
            resultText.color = new Color(0.81176470588f, 0.81176470588f, 0.07450980392f);
        }

        if(endgame.getIsGameLost()){
            resultText.text = "You lost :(";
            resultText.color = new Color(0.74117647058f, 0f, 0f);
            resultText.rectTransform.localPosition = new Vector3(resultText.rectTransform.localPosition.x, 3.59f, resultText.rectTransform.localPosition.z);
            resultText.fontSize = 70;
        }
        resultScreen.SetActive(true);
    }

    void PlayAgainBtnFun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToMenuBtnFun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}

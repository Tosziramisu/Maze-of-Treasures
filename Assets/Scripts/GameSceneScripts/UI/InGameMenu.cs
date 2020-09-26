using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MazeOfTreasures.GameScene.UI
{
    internal class InGameMenu : MonoBehaviour
    {
        [SerializeField] private Text remainingTreasures = default;

        [SerializeField] private TreasureManager treasureManager = default;

        [SerializeField] private GameObject resultScreen = default;
        [SerializeField] private GameObject pauseScreen = default;

        [SerializeField] private Text resultText = default;


        private int currentremainingTreasuresCount;

        private void Start()
        {
            StateOfGame.SharedInstance.isGameFinished = false;
            StateOfGame.SharedInstance.isGameWon = false;
            StateOfGame.SharedInstance.isGameLost = false;

            Time.timeScale = 1;
            Cursor.visible = false;
            
            currentremainingTreasuresCount = treasureManager.AmmountOfTreasures;
            remainingTreasures.text = "Remaining treasures: " + currentremainingTreasuresCount.ToString();
        }

        private void Update()
        {
            SetTheAmmountOfRemainingTreasures();

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                    ShowPauseScreen();

            if(currentremainingTreasuresCount == 0)
                StateOfGame.SharedInstance.isGameWon = true;

            if(StateOfGame.SharedInstance.getIsGameFinished())
                ShowResultScreen();   
        }

        private void SetTheAmmountOfRemainingTreasures()
        {
            if(currentremainingTreasuresCount > treasureManager.AmmountOfTreasures){
                currentremainingTreasuresCount = treasureManager.AmmountOfTreasures;
                remainingTreasures.text = "Remaining treasures: " + currentremainingTreasuresCount.ToString();
            }
        }

        public void ShowPauseScreen()
        {
            Time.timeScale = 0;
            Cursor.visible = true;

            pauseScreen.SetActive(!pauseScreen.activeSelf);
        }

        private void ShowResultScreen()
        {
            Time.timeScale = 0;
            Cursor.visible = true;

            if(StateOfGame.SharedInstance.getIsGameLost() || (StateOfGame.SharedInstance.getIsGameLost() && StateOfGame.SharedInstance.getIsGameWon())){
                resultText.text = "You lost :(";
                resultText.color = new Color(0.74117647058f, 0f, 0f);
                resultText.rectTransform.localPosition = new Vector3(resultText.rectTransform.localPosition.x, 3.59f, resultText.rectTransform.localPosition.z);
                resultText.fontSize = 70;
            }
            else if(StateOfGame.SharedInstance.getIsGameWon()){
                resultText.text = "Congratulations\nYou Won!";
                resultText.color = new Color(0.81176470588f, 0.81176470588f, 0.07450980392f);
            }

            
            resultScreen.SetActive(true);
        }

        public void PlayAgainBtnFun()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void BackToMenuBtnFun()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }

        public void BackToGameBtnFun()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            pauseScreen.SetActive(!pauseScreen.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MazeOfTreasures.MainMenuScene.UI
{
    internal class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            Cursor.visible = true;
        }

        public void playTheGameBtnFun()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void exitTheGameBtnFun()
        {
            Application.Quit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playTheGame;
    public Button exitTheGame;

    void Start()
    {
        Cursor.visible = true;

        if( playTheGame != null) 
            playTheGame.onClick.AddListener(playTheGameBtnFun);

        if( exitTheGame != null) 
            exitTheGame.onClick.AddListener(exitTheGameBtnFun);
    }

    void playTheGameBtnFun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void exitTheGameBtnFun()
    {
        Application.Quit();
    }
}

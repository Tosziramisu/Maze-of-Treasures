using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TreasureManager treasureManager;
    public bool isGameFinished = false;
    public bool isGameWon = false;
    public bool isGameLost = false;

    public bool getIsGameFinished() => isGameFinished;
    public bool getIsGameWon(){
        isGameWon = treasureManager.AmmountOfTreasures == 0 ? true : false;
        return isGameWon;
    }
    public bool getIsGameLost() => isGameLost;
}
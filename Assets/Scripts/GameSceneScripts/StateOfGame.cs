using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene
{
    internal class StateOfGame
    {
        private static StateOfGame instance = null;
        internal static StateOfGame SharedInstance {
            get {
                if (instance == null) {
                    instance = new StateOfGame ();
                }
                return instance;
            }
        }

        internal int currentAmmountOfTreasures;
        internal bool isGameFinished = false;
        internal bool isGameWon = false;
        internal bool isGameLost = false;

        internal bool getIsGameFinished() => isGameFinished;
        internal bool getIsGameWon(){
            isGameWon = currentAmmountOfTreasures == 0 ? true : false;
            return isGameWon;
        }
        internal bool getIsGameLost() => isGameLost;
    }
}
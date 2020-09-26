using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene
{
    internal class StateOfGame
    {
        private static StateOfGame instance = null;
        public static StateOfGame SharedInstance {
            get {
                if (instance == null) {
                    instance = new StateOfGame ();
                }
                return instance;
            }
        }
        public int currentAmmountOfTreasures;
        public bool isGameFinished = false;
        public bool isGameWon = false;
        public bool isGameLost = false;

        public bool getIsGameFinished() => isGameFinished;
        public bool getIsGameWon(){
            isGameWon = currentAmmountOfTreasures == 0 ? true : false;
            return isGameWon;
        }
        public bool getIsGameLost() => isGameLost;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeOfTreasures.GameScene.Player;
using MazeOfTreasures.GameScene.Music;

namespace MazeOfTreasures.GameScene
{
    internal class GameManager : MonoBehaviour
    {
        private void Start()
        {
            StateOfGame.SharedInstance.isGameFinished = false;
            StateOfGame.SharedInstance.isGameWon = false;
            StateOfGame.SharedInstance.isGameLost = false;

            EffectsOnPlayer.SharedInstance.invisibleItemFound = false;
            EffectsOnPlayer.SharedInstance.invisibleItemUsed = false;
            EffectsOnPlayer.SharedInstance.hasteItemFound = false;

            MusicManager.SharedInstance.playingPlayerSpottedMusic = false;
            MusicManager.SharedInstance.playingExploringMusic = false;
            MusicManager.SharedInstance.playingLostMusic = false;
        }
    }
}

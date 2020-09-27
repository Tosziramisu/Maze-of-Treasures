using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MazeOfTreasures.GameScene.Music;

namespace MazeOfTreasures.GameScene.Enemy.PlayerAware
{
    internal class MoveToPlayerLastKnownPositionState : PlayerAwareState
    {
        [SerializeField] private NavMeshAgent agent = default;
        private Vector3 playerCurrentPosition;
        internal override IEnumerator Execute(EnemyStateMachine enemyStateMachine)
        {
            agent.SetDestination(playerPosition);
            while (!InPosition(playerPosition)) 
            {
                yield return new WaitForFixedUpdate();
                if(!isPlayerStillVisible)
                {
                    playerCurrentPosition = playerPosition;
                    agent.SetDestination(playerCurrentPosition);
                    while (!InPosition(playerCurrentPosition)) 
                    {
                        yield return new WaitForFixedUpdate();
                    }
                    MusicManager.SharedInstance.playingExploringMusic = true;
                    enemyStateMachine.ResetStateMachine();
                }
            }
            MusicManager.SharedInstance.playingLostMusic = true;
            StateOfGame.SharedInstance.isGameLost = true;
            StateOfGame.SharedInstance.isGameFinished = true;
        }
    }
}

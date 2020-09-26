using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
                    enemyStateMachine.ResetStateMachine();
                }
            }
            StateOfGame.SharedInstance.isGameLost = true;
            StateOfGame.SharedInstance.isGameFinished = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerLastKnownPositionState : PlayerAwareState
{
    public EndGame endgame;
    public NavMeshAgent agent;
    private Vector3 playerCurrentPosition;
    public override IEnumerator Execute(EnemyStateMachine enemyStateMachine)
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
        isEnemyCatchedPlayer = true; 
        endgame.isGameFinished = true;
        endgame.isGameLost = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MazeOfTreasures.GameScene.Enemy.PatrolRoute
{
    internal class PatrolState : State
    {
        [SerializeField] private NavMeshAgent agent = default;
        [SerializeField] private PatrolRoute patrolRoute = default;
        [SerializeField] private float rotationSpeed = 5f;
        
        private Vector3 Direction => (patrolRoute.GoalPosition - transform.position).normalized;
        private bool IsCheckPointReached => Vector3.Distance(transform.position, patrolRoute.GoalPosition) < 0.25f;
        private bool IsFacingTarget => Vector3.Dot(transform.forward, Direction) >= 0.9999f;

        internal override IEnumerator Execute(EnemyStateMachine enemyStateMachine)
        {
            while (true)
            {
                yield return RotateTowardsCheckpoint();
                yield return MoveTowardsCheckpoint();
                yield return NextCheckpoint();
            }
        }

        private IEnumerator RotateTowardsCheckpoint()
        {
            while(!IsFacingTarget)
            {
                yield return new WaitForFixedUpdate();
                Quaternion lookRotation = Quaternion.LookRotation(Direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }

        private IEnumerator MoveTowardsCheckpoint()
        {
            agent.SetDestination(patrolRoute.GoalPosition);
            while(!IsCheckPointReached)
                yield return new WaitForFixedUpdate();
        }

        private IEnumerator NextCheckpoint()
        {
            yield return new WaitForSeconds(1f);
            patrolRoute.GoalReached();
        }
}
}

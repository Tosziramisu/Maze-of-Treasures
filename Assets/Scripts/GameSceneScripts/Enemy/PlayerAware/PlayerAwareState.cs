using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Enemy.PlayerAware
{
    internal class PlayerAwareState : State
    {
        internal Vector3 playerPosition { get; set; }
        internal Vector3 Direction => (playerPosition - transform.position);
        internal bool isPlayerStillVisible = false;
        internal bool InPosition(Vector3 playerPos) => Vector3.Distance(transform.position, playerPos) < 0.25f;
        internal float DistanceBetweenEnemyAndPlayer => Vector3.Distance(transform.position, playerPosition);
    }
}

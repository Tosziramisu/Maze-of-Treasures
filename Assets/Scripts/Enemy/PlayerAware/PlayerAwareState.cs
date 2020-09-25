using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareState : State
{
    public Vector3 playerPosition { get; set; }
    public Vector3 Direction => (playerPosition - transform.position);
    public bool isPlayerStillVisible = false;
    public bool isEnemyCatchedPlayer = false;
    public bool InPosition(Vector3 playerPos) => Vector3.Distance(transform.position, playerPos) < 0.25f;
    public float DistanceBetweenEnemyAndPlayer => Vector3.Distance(transform.position, playerPosition);
}

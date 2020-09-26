using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Enemy
{
    internal abstract class State : MonoBehaviour
    {
        internal virtual IEnumerator Execute(EnemyStateMachine enemyStateMachine)
        {
            yield break;
        }
    }
}

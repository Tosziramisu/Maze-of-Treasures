using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Enemy
{
    internal class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State initialState = default;
        private Coroutine _coroutine;
        private void Start() => ResetStateMachine();
        internal void SetState(State state)
        {
            if(_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(state.Execute(this));
        }

        internal void ResetStateMachine() => SetState(initialState);
    }
}

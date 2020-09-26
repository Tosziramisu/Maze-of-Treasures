using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Enemy.PatrolRoute
{
    internal class PatrolRoute : MonoBehaviour
    {
        [SerializeField] private List<PatrolRouteNode> nodes = new List<PatrolRouteNode>();
        private int nodesIterator = 1;
        internal Vector3 GoalPosition => (nodes != null) && (nodes.Count > 0) ? nodes[nodesIterator].transform.position : Vector3.zero;
        internal void GoalReached() => nodesIterator = (nodesIterator + 1) % nodes.Count;
    }
} 

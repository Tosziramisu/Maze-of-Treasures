using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] private List<PatrolRouteNode> nodes = new List<PatrolRouteNode>();
    private int nodesIterator = 1;
    public Vector3 GoalPosition => (nodes != null) && (nodes.Count > 0) ? nodes[nodesIterator].transform.position : Vector3.zero;
    public void GoalReached() => nodesIterator = (nodesIterator + 1) % nodes.Count;
}

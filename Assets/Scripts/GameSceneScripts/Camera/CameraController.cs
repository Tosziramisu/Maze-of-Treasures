using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Camera
{
    internal class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player = default;

        private void LateUpdate()
        {
            Vector3 newPosition = player.position;
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Player
{
    internal class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController controller = default;
        [SerializeField] internal float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        
        private void Update()
        {
            Quaternion lookRotation;
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if(move != Vector3.zero)
            {
                lookRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
            controller.Move(move * Time.deltaTime * moveSpeed);

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Player
{
    internal class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController controller = default;
        [SerializeField] private float moveSpeed = 5f;
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

            // if(CheckIfEnemyNotTooClose())
            // {
            //     StateOfGame.SharedInstance.isGameFinished = true;
            //     StateOfGame.SharedInstance.isGameLost = true;
            // }

        }

        private bool CheckIfEnemyNotTooClose()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50f);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.gameObject.layer == 10)
                {
                    Debug.Log("Widzę przeciwnika: "+hitCollider.transform.name);
                    return true;
                }
            }
            return false;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.tag == "StartingPoint"){
                if(StateOfGame.SharedInstance.getIsGameWon())
                    StateOfGame.SharedInstance.isGameFinished = true;
            }

            if (hit.transform.tag == "Treasure"){
                Destroy(hit.gameObject);
            }

            if (hit.gameObject.layer == 10){
                StateOfGame.SharedInstance.isGameLost = true;
                StateOfGame.SharedInstance.isGameFinished = true;
            }
        }
    }
}


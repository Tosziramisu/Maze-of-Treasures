using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;

    public EndGame endGame;
    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "StartingPoint"){
            if(endGame.getIsGameWon())
                endGame.isGameFinished = true;
        }

        if (hit.transform.tag == "Treasure"){
            Destroy(hit.gameObject);
        }
    }
}

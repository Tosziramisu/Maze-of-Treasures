using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeOfTreasures.GameScene.Music;

namespace MazeOfTreasures.GameScene.Player
{
    internal class PlayerCollisionManager : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        private bool invisibleItemPicked = false;

        private string currentPlayerTag;
        private string invisibleTag = "PlayerBecomeInvisible";

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            currentPlayerTag = transform.tag;
        }

        private void Update()
        {
            if(invisibleItemPicked)
                if(Input.GetKeyDown(KeyCode.I))
                {
                    transform.tag = invisibleTag;
                    EffectsOnPlayer.SharedInstance.invisibleItemUsed = true;
                    invisibleItemPicked = false;
                    StartCoroutine(MakePlayerInvisibleTemporarily()); 
                }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.tag == "StartingPoint"){
                if(StateOfGame.SharedInstance.getIsGameWon())
                {
                    MusicManager.SharedInstance.audioClipsPlayingConditions[3] = true;
                    StateOfGame.SharedInstance.isGameFinished = true;
                }
            }

            if (hit.transform.tag == "Treasure"){
                Destroy(hit.gameObject);
            }

            if (hit.gameObject.layer == 10){
                MusicManager.SharedInstance.audioClipsPlayingConditions[2] = true;
                StateOfGame.SharedInstance.isGameLost = true;
                StateOfGame.SharedInstance.isGameFinished = true;
            }

            if(hit.transform.tag == "SpeedBooster")
            {
                Destroy(hit.gameObject);
                EffectsOnPlayer.SharedInstance.hasteItemFound = true;
                playerMovement.moveSpeed += 5f;
                StartCoroutine(RaisePlayerSpeedTemporarily()); 
            }

            if(hit.transform.tag == "InvisibleItem")
            {
                Destroy(hit.gameObject);
                EffectsOnPlayer.SharedInstance.invisibleItemFound = true;
                invisibleItemPicked = true;
            }
        }

        private IEnumerator RaisePlayerSpeedTemporarily()
        { 
            yield return new WaitForSeconds(EffectsOnPlayer.SharedInstance.hasteItemDuration);
            playerMovement.moveSpeed -= EffectsOnPlayer.SharedInstance.hasteAmmount;
        }

        private IEnumerator MakePlayerInvisibleTemporarily()
        { 
            yield return new WaitForSeconds(EffectsOnPlayer.SharedInstance.invisibleItemDuration);
            transform.tag = currentPlayerTag;
        }
    }
}

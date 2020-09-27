using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Music
{
    internal class MusicPlayer : MonoBehaviour
    {
        public AudioSource audioSource = default;
        public AudioClip[] audioClipArray = default;

        private void Start()
        {
            audioSource.clip = audioClipArray[0];
            audioSource.Play();
        }

        private void Update()
        {
            if(MusicManager.SharedInstance.playingExploringMusic)
            {
                audioSource.Stop();
                MusicManager.SharedInstance.playingExploringMusic = false;
                audioSource.clip = audioClipArray[0];
                audioSource.Play();
            }
            else if(MusicManager.SharedInstance.playingPlayerSpottedMusic)
            {
                audioSource.Stop();
                MusicManager.SharedInstance.playingPlayerSpottedMusic = false;
                audioSource.clip = audioClipArray[1];
                audioSource.Play();
            }
            else if(MusicManager.SharedInstance.playingLostMusic)
            {
                audioSource.Stop();
                MusicManager.SharedInstance.playingLostMusic = false;
                audioSource.clip = audioClipArray[2];
                audioSource.Play();
            }
            MusicManager.SharedInstance.currentMusic = System.Array.IndexOf(audioClipArray, audioSource.clip);
        }
    }
}

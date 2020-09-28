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
            MusicManager.SharedInstance.audioClipsPlayingConditions = new bool[audioClipArray.Length]; 
            //0 - PlayerSpotted | 1 - Exploring | 2 - Lost | 3 - Victory
            for(int i=0; i<MusicManager.SharedInstance.audioClipsPlayingConditions.Length; i++)
            {
                MusicManager.SharedInstance.audioClipsPlayingConditions[i] = false;
            }
            audioSource.clip = audioClipArray[0];
            audioSource.Play();
        }

        private void Update()
        {
            for(int i=0; i<MusicManager.SharedInstance.audioClipsPlayingConditions.Length; i++)
            {
                if(MusicManager.SharedInstance.audioClipsPlayingConditions[i])
                {
                    audioSource.Stop();
                    MusicManager.SharedInstance.audioClipsPlayingConditions[i] = false;
                    audioSource.clip = audioClipArray[i];
                    audioSource.Play();
                }
            }
            
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            MusicManager.SharedInstance.currentMusic = System.Array.IndexOf(audioClipArray, audioSource.clip);
        }
    } 
}

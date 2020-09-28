using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Music
{
    internal class MusicManager
    {
        private static MusicManager instance = null;
            internal static MusicManager SharedInstance {
                get {
                    if (instance == null) {
                        instance = new MusicManager ();
                    }
                    return instance;
                }
            }
      
        internal bool[] audioClipsPlayingConditions;//0 - PlayerSpotted | 1 - Exploring | 2 - Lost | 3 - Victory
        internal int currentMusic = 0;

    }
}

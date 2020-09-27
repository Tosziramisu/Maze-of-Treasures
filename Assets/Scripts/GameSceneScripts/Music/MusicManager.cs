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
        
        internal bool playingPlayerSpottedMusic = false;
        internal bool playingExploringMusic = false;
        internal bool playingLostMusic = false;
        internal int currentMusic = 0;

    }
}

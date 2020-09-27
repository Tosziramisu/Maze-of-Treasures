using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene.Player
{    
    internal class EffectsOnPlayer
    {
        private static EffectsOnPlayer instance = null;
        internal static EffectsOnPlayer SharedInstance {
            get {
                if (instance == null) {
                    instance = new EffectsOnPlayer ();
                }
                return instance;
            }
        }

        internal bool invisibleItemFound = false;
        internal bool invisibleItemUsed = false;
        internal bool hasteItemFound = false;

        internal float invisibleItemDuration = 15f;
        internal float hasteItemDuration = 5f;

        internal float hasteAmmount = 5f;
    }
}

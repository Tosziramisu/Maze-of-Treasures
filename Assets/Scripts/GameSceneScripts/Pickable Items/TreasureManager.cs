using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeOfTreasures.GameScene
{
    internal class TreasureManager : MonoBehaviour
    {
        internal int AmmountOfTreasures => this.transform.childCount;

        private void Update()
        {
            StateOfGame.SharedInstance.currentAmmountOfTreasures = AmmountOfTreasures;
        }
    }
}

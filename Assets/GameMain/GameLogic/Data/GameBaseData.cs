using System;
using UnityEngine;

namespace Wcng
{
    [CreateAssetMenu(fileName = "GameBaseData",menuName = "Data/GameBaseData")]
    public class GameBaseData : EntityData
    {
        public int moneyTotal;

        public override void ReSet()
        {
            moneyTotal = 20;
        }
    }
}

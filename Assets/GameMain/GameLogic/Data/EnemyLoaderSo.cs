using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wcng
{
    [Serializable]
    public struct EnemyInitData
    {
        public string name;
        public Vector3 pos;
    }
    [CreateAssetMenu(fileName = "EnemyLoader",menuName = "Data/EnemyLoader")]
    public class EnemyLoaderSo : ScriptableObject
    {
        public List<EnemyInitData> loadEnemyList;
    }
}

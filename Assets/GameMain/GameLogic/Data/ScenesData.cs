using System.Collections.Generic;
using UnityEngine;

namespace Wcng
{
    [CreateAssetMenu(fileName = "SceneData",menuName = "Data/SceneData")]
    public class ScenesData : ScriptableObject
    {
        [field: SerializeField] public Vector3 BackGroundStartPos { get; set; }
        [field: SerializeField] public Vector3 PlayerInitPos { get; set; }
        [field: SerializeField] public Vector3 CombatTriggerPos { get; set; }
    }
}

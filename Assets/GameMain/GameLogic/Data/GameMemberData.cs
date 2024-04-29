using Mirror;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class GameMemberData : EntityData
    {
        [field: Header("属性信息")] [field: SerializeField] public int MaxHealth { get; set; }
        [field:SerializeField] public float CurrentHealth { get; set; }
        [field:SerializeField] public float BaseAttack { get; set; }
        [field:SerializeField] public float BaseDefense { get; set; }
    }
}

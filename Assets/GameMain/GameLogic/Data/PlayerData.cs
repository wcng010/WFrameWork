using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "PlayerData")]
    public class PlayerData : GameMemberData
    {
        [field: Header("角色属性")] [field: SerializeField] public Vector2 SpriteSize { get; set; }
        [field: SerializeField] public float WalkMaxSpeed { get; set; }
        [field: SerializeField] public float RunMaxSpeed { get; set; }
        [field: SerializeField] public float JumpMaxSpeed { get; set; }
        [field: SerializeField] public float WalkAcceleration { get; set; }
        [field: SerializeField] public float RunAcceleration { get; set; }
        [field: SerializeField] public float JumpAcceleration { get; set; }
        [field: SerializeField] public float JumpSpeedUpTime { get; set; }
        public override void ReSet()
        {
            MaxHealth = 5;
            BaseAttack = 1;
        }
    }
}

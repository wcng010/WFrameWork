using UnityEngine;

namespace Wcng
{
    [CreateAssetMenu(menuName = "Data/EnemyData", fileName = "EnemyData")]
    public class EnemyData : GameMemberData
    {
        [field: SerializeField] public float AttackRange { get; set; }
        [field: SerializeField] public float MoveRange { get; set; }
        [field: SerializeField] public float WarningRange { get; set; }
        [field: SerializeField] public float MoveSpeed { get; set; }
        [field: SerializeField] public float MoveTime { get; set; }
    }
}

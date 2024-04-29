using System;
using UnityEngine;

namespace Wcng
{
    [Serializable]
    public enum ShopItemType
    {
        HealthUp,
        AttackUp,
        CardNumUp,
    }

    [CreateAssetMenu(fileName = "ShopItemData",menuName = "Data/ShopItemData")]
    public class ShopItemData : ScriptableObject
    {
        public ShopItemType itemType;
        public CardType cardType;
        public int usedMoney;
        public string description;
        public Sprite uISprite;
    }
}

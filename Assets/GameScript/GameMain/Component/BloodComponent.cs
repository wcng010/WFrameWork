using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GameScript.GameMain.Component
{
    
    public enum BarType
    {
        Health,
        Blue,
        Energy
    }

    public class BloodComponent : MonoBehaviour,IComponent
    {
        [SerializeField] private List<Image> healthBarImages;
        [SerializeField] private List<Image> blueBarImages;

        public void SetHealthMessage(float rate, BarType barType)
        {
            if (rate > 1 || rate < 0) return;
            List<Image> barImage = null;
            switch (barType)
            {
                case BarType.Health : barImage = healthBarImages; break;
                case BarType.Blue : barImage = blueBarImages; break;
                default: return;
            }
            
            if (rate < 0.5f)
            {
                barImage[1].fillAmount = 0;
                barImage[0].fillAmount = rate * 2;
            }
            else
            {
                barImage[1].fillAmount = (1 - rate) * 2;
                barImage[0].fillAmount = 1;
            }
        }
    }
}

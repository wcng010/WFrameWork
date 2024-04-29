using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;


namespace Wcng
{
    public class ShopSystem : System,ISystem
    {
        public override System SystemInit()
        {
            ManagerInit();
            return base.SystemInit();
        }

        public override void SystemDestroy()
        {
            Destroy(gameObject);
        }

        public override void ManagerInit()
        {
            
        }
    }
}

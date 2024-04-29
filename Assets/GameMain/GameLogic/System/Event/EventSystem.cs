using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class EventSystem : System,ISystem
    {
       private List<Manager> eventCentreManager = new List<Manager>();
       public override System SystemInit()
       {
           ManagerInit();
           return base.SystemInit();
       }

       public override void SystemDestroy()
       {
           for (int i = 0; i < eventCentreManager.Count; ++i)
           {
               eventCentreManager[i].OnManagerDestroy();
           }
           Destroy(gameObject);
       }

       public override void ManagerInit()
       {
           
       }

       public T GetManager<T>() where T :Manager
       {
           return (T)eventCentreManager.Find((manager) => manager.GetType() == typeof(T));
       }
       
    }
}

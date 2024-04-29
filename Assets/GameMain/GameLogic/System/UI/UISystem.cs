using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class UISystem : System
    {
        private List<Manager> _managerUIList;
        
        public override System SystemInit()
        {
            _managerUIList = new List<Manager>(transform.GetComponentsInChildren<Manager>());
            foreach (var manager in _managerUIList)
            {
                manager.OnManagerInit();
            }
            return base.SystemInit();
        }

        public override void SystemDestroy()
        {
            for (int i = 0; i < _managerUIList.Count; i++)
            {
                _managerUIList[i].OnManagerDestroy();
            }
            Destroy(gameObject);
        }

        public override void ManagerInit()
        {
            
        }


        public T GetManager<T>() where T :Manager
        {
            return (T)_managerUIList.Find((manager) => manager.GetType() == typeof(T));
        }
    }
}

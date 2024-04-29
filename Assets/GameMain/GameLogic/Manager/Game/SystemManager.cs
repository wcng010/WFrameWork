using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public static class SystemManager 
    {
        public static readonly List<System> SystemList = new List<System>();
        public static DataSystem DataSystem { get; set; }
        public static LogSystem LogSystem { get; set; }
        public static EventSystem EventSystem { get; set; }
        public static InputSystem InputSystem { get; set; }
        public static AudioSystem AudioSystem { get; set; }
        public static UISystem UISystem { get; set; }
        public static ResourceSystem ResourceSystem { get; set; }
        public static SceneSystem SceneSystem { get; set; }
        public static WebSystem WebSystem { get; set; }
        public static CameraSystem CameraSystem { get; set; }
        public static ShopSystem ShopSystem { get; set; }

        public static T GetSystem<T>() where T : System
        {
            var comp = SystemList.OfType<T>().FirstOrDefault();
            if (comp)
                return comp;
            else
            {
                Debug.LogWarning($"{typeof(T)} not found ");
            }
            return null;
        }

        public static T GetSystem<T>([NotNull] ref T value) where T : System
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            value = GetSystem<T>();
            return value;
        }

        public static void AddSystem<T>(T system) where T : System
        {
            SystemList.Add(system);
        }
        
        public static T CreatManager<T>(Transform parent) where T :Manager
        {
            GameObject sys = new GameObject(typeof(T).Name);
            sys.transform.parent = parent;
            return sys.AddComponent<T>();
        }
    }
}
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
        public static DataSystem DataSystem => GetSystem<DataSystem>();
        public static LogSystem LogSystem => GetSystem<LogSystem>();
        public static EventSystem EventSystem => GetSystem<EventSystem>();
        public static InputSystem InputSystem => GetSystem<InputSystem>();
        public static AudioSystem AudioSystem => GetSystem<AudioSystem>();
        public static UISystem UISystem => GetSystem<UISystem>();
        public static ResourceSystem ResourceSystem => GetSystem<ResourceSystem>();
        public static SceneSystem SceneSystem => GetSystem<SceneSystem>();
        public static WebSystem WebSystem => GetSystem<WebSystem>();
        public static CameraSystem CameraSystem => GetSystem<CameraSystem>();
        public static ShopSystem ShopSystem => GetSystem<ShopSystem>();

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
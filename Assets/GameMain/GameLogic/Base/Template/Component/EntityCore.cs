using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Wcng
{
    public class EntityCore: MonoBehaviour
    {
        private readonly List<CoreComponent> _coreComponents = new List<CoreComponent>();
        
        public void AddComponent(CoreComponent component)
        {
            if (!_coreComponents.Contains(component))
            {
                _coreComponents.Add(component.GetMyComponent(this));
            }
        }

        public T GetCoreComponent<T>() where T : CoreComponent
        {
            //查找列表中符合要求的CoreComponent
            var comp = _coreComponents.OfType<T>().FirstOrDefault();

            if (comp)
                return comp;

            comp = GetComponentInChildren<T>();

            if (comp)
                return comp;

            Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
            return null;
        }

        public T GetCoreComponent<T>([NotNull] ref T value) where T : CoreComponent
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            value = GetCoreComponent<T>();
            return value;
        }
        
    }
}
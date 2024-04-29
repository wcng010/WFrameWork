using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class DataComponent : CoreComponent
    {
        public EntityData EntityData => _entityData? _entityData : _entityData = SystemManager.DataSystem.GetData(gameObject.name);

        private EntityData _entityData;
    }
}

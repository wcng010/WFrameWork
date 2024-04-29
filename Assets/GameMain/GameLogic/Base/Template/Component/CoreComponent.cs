using System;
using Mirror;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    [Serializable]
    public class CoreComponent : MonoBehaviour,IComponent
    {
        protected EntityCore MyCore;
        public CoreComponent GetMyComponent(EntityCore core)
        {
            MyCore = core;
            return this;
        }
    }
}
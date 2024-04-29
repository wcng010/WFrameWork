using Mirror;
using UnityEngine;

namespace Wcng
{
    public abstract class Entity : MonoBehaviour
    {
        public void UnActive() => SystemManager.ResourceSystem.RecyclePrefab(gameObject);
    }
}

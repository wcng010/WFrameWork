using UnityEngine;

namespace Wcng
{
    public abstract class System : MonoBehaviour
    {
        public virtual System SystemInit()
        {
            ManagerInit();
            return this;
        }

        public virtual void SystemDestroy()
        {
            Destroy(gameObject);
        }

        public abstract void ManagerInit();
    }
}

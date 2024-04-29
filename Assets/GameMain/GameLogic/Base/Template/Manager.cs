using UnityEngine;

namespace Wcng
{
    public abstract class Manager : MonoBehaviour
    {
        public virtual void OnManagerInit()
        {
            OnManagerOpen();
        }

        public virtual void OnManagerDestroy()
        {
            Destroy(gameObject);
        }

        public abstract void OnManagerOpen();
        public abstract void OnManagerClose();
    }
}

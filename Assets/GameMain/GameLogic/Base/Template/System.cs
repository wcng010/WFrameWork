using Sirenix.OdinInspector;
namespace Wcng
{
    
    public abstract class System : SerializedMonoBehaviour
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

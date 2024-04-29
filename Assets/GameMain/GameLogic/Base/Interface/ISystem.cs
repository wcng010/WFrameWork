namespace Wcng
{
    public interface ISystem
    {
        public System SystemInit();
        public void  ManagerInit();
        public void SystemDestroy();
    }
}
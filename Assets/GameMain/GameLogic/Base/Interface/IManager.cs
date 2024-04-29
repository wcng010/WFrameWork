namespace Wcng
{
    public interface IManager
    {
        public void OnManagerInit();
        public void OnManagerDestroy();
        public void OnManagerOpen();
        public void OnManagerClose();
    }
}
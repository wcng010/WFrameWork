using System;
using Object = UnityEngine.Object;
namespace Wcng
{
    [Serializable]
    public struct ResourcePoolItem
    {
        public Object item;
        public int usedTime;
        public int loadedTime;

        public ResourcePoolItem(Object item,int usedTime, int loadedTime)
        {
            this.item = item;
            this.usedTime = usedTime;
            this.loadedTime = loadedTime;
        }

        public void AddUsedCount() => ++usedTime;
        public void SetUsedCountZero() => usedTime = 0;

    }
}
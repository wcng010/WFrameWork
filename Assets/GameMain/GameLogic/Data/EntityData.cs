using Mirror;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class EntityData : ScriptableObject,IDataReset
    {
        [field:Header("编号")][field:SerializeField] public int ID { get; set; }
        [field:Header("持有者名称")][field:SerializeField]public string OwnerName { get; set; }
        public virtual void ReSet()
        {
            
        }
    }
}

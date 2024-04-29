using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class DataSystem:System,ISystem
    {
        [SerializeField] private List<EntityData> entityData = new List<EntityData>();
        [SerializeField] private List<EntityData> entityDataTemp = new List<EntityData>();
        public EntityData GetData(string name,bool isBaseData = false)
        {
            EntityData findData;

            if (isBaseData)
            {
                //去原数据中找
                findData = entityData.Find((data) =>
                {
                    return name.Contains(data.OwnerName);
                });
                return findData;
            }
            else
            {
                //先在复制品中找
                findData = entityDataTemp.Find(
                    (data) => { return String.Compare(data.OwnerName, name, StringComparison.Ordinal) == 0; });
                //如果找不到
                if (!findData)
                {
                    //再去原数据中找
                    findData = entityData.Find((data) => { return name.Contains(data.OwnerName); });
                    if (findData)
                    {
                        EntityData data = Instantiate(findData);
                        findData = data;
                        data.OwnerName = name;
                        entityDataTemp.Add(data);
                    }
                    else
                    {
                        Debug.Log("failed to load " + name + "'s Data");
                        //SystemManager.LogSystem.Log(MoudelType.NULL,"failed to load "+name+"'s Data",LogType.Warning);
                        return null;
                    }
                }

                return findData;
            }
        }

        public void DeleteData(string name)
        {
            //先在复制品中找
            var findData = entityDataTemp.Find(
                (data) => { return String.Compare(data.OwnerName, name, StringComparison.Ordinal) == 0; });
            entityDataTemp.Remove(findData);
            Destroy(findData);
        }

        public override void ManagerInit()
        {
            
        }
    }
}
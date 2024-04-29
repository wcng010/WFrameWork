using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Wcng
{
    public enum ResourceType
    {
        OnceTime,
        MoreTime
    }

    public class ResourceSystem : System,ISystem
    { 
        //资源对象池,对长时间没有使用和使用次数少于一定数目资源进行卸载
        [SerializeField] private Dictionary<string, ResourcePoolItem> loadedResourcePool = new Dictionary<string, ResourcePoolItem>();
        //失活对象的对象池，定时的清空
        [SerializeField] private Dictionary<string, Object> unActiveResourcePool = new Dictionary<string, Object>();

        
        public override System SystemInit()
        {
            ManagerInit();
            return base.SystemInit();
        }

        public override void SystemDestroy()
        {
            Destroy(gameObject);
        }

        public override void ManagerInit()
        {
            InvokeRepeating(nameof(ClearPoolItem),600f,1f);
        }

        //第一次创建
        public GameObject CreatePrefab(string assetsName, Transform parent,ResourceType resourceType,bool isActive = true)
        {
            if (!string.IsNullOrEmpty(assetsName))
            {
                //当前资源仅创建一次，得到资源就卸载AB包。
                if (resourceType == ResourceType.OnceTime)
                {
                    var obj = Addressables.InstantiateAsync(assetsName, parent).WaitForCompletion().gameObject;
                    obj.name += Guid.NewGuid();
                    return obj;
                }
                //需要多次加载资源，保存副本
                if (resourceType == ResourceType.MoreTime)
                {
                    //先在失活对象池查找
                    //能够在失活池找到，直接激活使用
                    foreach (var key in unActiveResourcePool.Keys)
                    {
                        if (key.Contains(assetsName))
                        {
                            if (unActiveResourcePool[key] != null)
                            {
                                GameObject objTemp = (GameObject)(unActiveResourcePool[key]);
                                objTemp.SetActive(true);
                                objTemp.transform.SetParent(parent);
                                unActiveResourcePool.Remove(objTemp.name);
                                return objTemp;
                            }
                            else
                            {
                                unActiveResourcePool.Remove(key);
                            }
                        }
                    }

                    ResourcePoolItem asset;
                    //不能在失活池找到,尝试在资源池查找
                    if (loadedResourcePool.TryGetValue(assetsName, out asset))
                    {
                        if (asset.item != null)
                        {
                            var objTemp = Instantiate((GameObject)asset.item, parent);
                            objTemp.name += Guid.NewGuid();
                            asset.AddUsedCount();
                            if (!isActive)
                            {
                                objTemp.SetActive(false);
                                unActiveResourcePool.TryAdd(objTemp.name, objTemp);
                            }

                            return objTemp;
                        }
                        else
                        {
                            loadedResourcePool.Remove(assetsName);
                        }
                    }
                    //资源未加载
                    else
                    {
                        //异步加载资源
                        var obj = Addressables.InstantiateAsync(assetsName, parent)
                            .WaitForCompletion().gameObject;
                        obj.name += Guid.NewGuid();
                        loadedResourcePool.TryAdd(assetsName,new ResourcePoolItem(obj, 0, 0));
                        if (!isActive)
                        {
                            unActiveResourcePool.TryAdd(obj.name, obj);
                            obj.SetActive(false);
                        }
                        return obj;
                    }
                }
            }
            SystemManager.LogSystem.Log(MoudelType.Resource, "Failed to Load" + assetsName, LogType.Error);
            return null;
        }

        //加载资源到内存池
        public void LoadAssets(string assetsName)
        {
            if(!loadedResourcePool.TryGetValue(assetsName,out _))
            {
                Addressables.LoadAssetAsync<GameObject>(assetsName).Completed +=
                obj =>
                {
                    loadedResourcePool.Add(assetsName, new ResourcePoolItem(obj.Result,0,0));
                };
            }
        }
        //卸载资源
        public void UnLoadAssets(string assetsName)
        { 
            ResourcePoolItem item;
            if (loadedResourcePool.TryGetValue(assetsName, out item))
            {
                loadedResourcePool.Remove(assetsName);
                Destroy(item.item);
            }
            else
            {
                SystemManager.LogSystem.Log(MoudelType.Resource, "Resource isn't Existed" + assetsName, LogType.Warning);
            }
        }
        
        public void RecyclePrefab(GameObject obj)
        {
            obj.SetActive(false);
            unActiveResourcePool.TryAdd(obj.name,obj);
        }
        
        public void ClearPoolItem()
        {
            foreach (var obj in unActiveResourcePool.Values)
            {
                if(obj != null) Destroy(obj);
            }
            unActiveResourcePool.Clear();
            List<string> delectKeys = new List<string>();
            foreach (var key in loadedResourcePool.Keys)
            {
                if (loadedResourcePool[key].usedTime == 0)
                {
                    //Destroy(loadedResourcePool[key].item);
                    delectKeys.Add(key);
                }
                else
                {
                    loadedResourcePool[key].SetUsedCountZero();
                }
            }
            for (int i = 0; i < delectKeys.Count; i++)
            {
                 loadedResourcePool.Remove(delectKeys[i]);
            }
            GC.Collect();
        }

        public void ClearPool()
        {
            unActiveResourcePool.Clear();
            loadedResourcePool.Clear();
        }

        
    }
}

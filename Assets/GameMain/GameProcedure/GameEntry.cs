using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Wcng
{
    public enum GameState
    {
        Online,
        Offline,
    }
    public class GameEntry :NormSingleton<GameEntry>
    {
        [Title("RunType")][PropertyOrder(-2)]
        public GameState gameState;
        [FoldoutGroup("Reference",-1)]
        public Transform entityGroup;
        [FoldoutGroup("Reference",0)]
        public Transform environment;
        [FoldoutGroup("Reference",2)]
        public Transform dynamicUI;
        [FoldoutGroup("Reference",3)]
        public Transform staticUI;
        [FoldoutGroup("Reference",1)] 
        [SerializeField] private Transform systemGroup;
        [FoldoutGroup("Setting")]
        [SerializeField] private List<SceneSystemSo> loadSystemSetting = new List<SceneSystemSo>();
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnLoadSystem;
        }

        private void OnLoadSystem(Scene arg0, LoadSceneMode arg1)
        {
            OnLoadSystem();
        }

        //加载系统，系统加载manager，manager进而加载负责的类
        private void OnLoadSystem()
        {
            /*
            for (int i = 0; i < loadSystemSetting.Count; i++)
            {
                if (loadSystemSetting[i].levelIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    //记录需加载的所有系统
                    List<Type> systemType = new List<Type>();
                    List<System> newLoadSystem = new List<System>();
                    foreach (var systemName  in loadSystemSetting[i].loadSystemNames)
                    {
                        if (systemName == "WebSystem")
                        {
                            systemType.Add(typeof(WebSystem));
                            //未创建
                            if (!SystemManager.WebSystem)
                            {
                                SystemManager.WebSystem = CreateSystem(systemName, systemGroup) as WebSystem; 
                                newLoadSystem.Add(SystemManager.WebSystem);
                            }
                        }
                        else if (systemName == "EventSystem")
                        {
                            systemType.Add(typeof(EventSystem));
                            //未创建
                            if (!SystemManager.EventSystem)
                            {
                                SystemManager.EventSystem = CreateSystem(systemName, systemGroup) as EventSystem;
                                newLoadSystem.Add(SystemManager.EventSystem);
                            }
                        }
                        else if (systemName == "ResourceSystem")
                        {
                            systemType.Add(typeof(ResourceSystem));
                            //未创建
                            if (!SystemManager.ResourceSystem)
                            {
                                SystemManager.ResourceSystem = CreateSystem(systemName, systemGroup) as ResourceSystem;
                                newLoadSystem.Add(SystemManager.ResourceSystem);
                            }
                            //已创建
                            else
                            {
                                SystemManager.ResourceSystem.ClearPool();
                            }
                        }
                        else if (systemName == "DataSystem")
                        {
                            systemType.Add(typeof(DataSystem));
                            //未创建
                            if (!SystemManager.DataSystem)
                            {
                                SystemManager.DataSystem = CreateSystem(systemName, systemGroup) as DataSystem;
                                newLoadSystem.Add(SystemManager.DataSystem);
                            }
                        }
                        else if (systemName == "InputSystem")
                        {
                            systemType.Add(typeof(InputSystem));
                            //未创建
                            if (!SystemManager.InputSystem)
                            {
                                SystemManager.InputSystem = CreateSystem(systemName, systemGroup) as InputSystem;
                                newLoadSystem.Add(SystemManager.InputSystem);
                            }
                        }
                        else if (systemName == "AudioSystem")
                        {
                            systemType.Add(typeof(AudioSystem));
                            //未创建
                            if (!SystemManager.AudioSystem)
                            {
                                SystemManager.AudioSystem = CreateSystem(systemName, systemGroup) as AudioSystem;
                                newLoadSystem.Add(SystemManager.AudioSystem);
                            }
                        }
                        else if (systemName == "SceneSystem")
                        {
                            systemType.Add(typeof(SceneSystem));
                            //未创建
                            if (!SystemManager.SceneSystem)
                            {
                                SystemManager.SceneSystem = CreateSystem(systemName, systemGroup) as SceneSystem;
                                newLoadSystem.Add(SystemManager.SceneSystem);
                            }
                        }
                        else if (systemName == "UISystem")
                        {
                            systemType.Add(typeof(UISystem));
                            //未创建
                            if (!SystemManager.UISystem)
                            {
                                SystemManager.UISystem = CreateSystem(systemName, systemGroup) as UISystem;
                                newLoadSystem.Add(SystemManager.UISystem);
                            }
                        }
                        else if (systemName == "CameraSystem")
                        {
                            systemType.Add(typeof(CameraSystem));
                            //未创建
                            if (!SystemManager.CameraSystem)
                            {
                                SystemManager.CameraSystem = CreateSystem(systemName, systemGroup) as CameraSystem;
                                newLoadSystem.Add(SystemManager.CameraSystem);
                            }
                        }
                        else if (systemName == "ShopSystem")
                        {
                            systemType.Add(typeof(ShopSystem));
                            //未创建
                            if (!SystemManager.ShopSystem)
                            {
                                SystemManager.ShopSystem = CreateSystem(systemName, systemGroup) as ShopSystem;
                                newLoadSystem.Add(SystemManager.ShopSystem);
                            }
                        }
                    }
                    for (int j = SystemManager.SystemList.Count-1; j >= 0; --j)
                    {
                        if(!systemType.Contains(SystemManager.SystemList[j].GetType()))
                        {
                            SystemManager.SystemList[j].SystemDestroy();
                            SystemManager.SystemList.RemoveAt(j);
                        }
                    }
                    for (int k = 0; k < newLoadSystem.Count; k++)
                    {
                        SystemManager.SystemList.Add(newLoadSystem[k]);
                    }
                }
            }*/
            
            for (int i = 0; i < loadSystemSetting.Count; i++)
            {
                if (loadSystemSetting[i].levelIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    for (int j = 0; j < loadSystemSetting[i].loadSystemTypes.Count; ++j)
                    {
                        //类传入错误
                        if (loadSystemSetting[i].loadSystemTypes[j].GetClass().BaseType != typeof(System))
                        {
                            Debug.Log("yhyh: Error Component Params: " + loadSystemSetting[i].loadSystemTypes[j].GetClass());
                            return;
                        }
                        //需添加
                        else if(!SystemManager.SystemList.Exists((system) => system.GetType() == loadSystemSetting[i].loadSystemTypes[j].GetClass()))
                        {
                            GameObject systemObj = new GameObject();
                            systemObj.name = loadSystemSetting[i].loadSystemTypes[j].name;
                            systemObj.transform.SetParent(systemGroup);
                            SystemManager.SystemList.Add(systemObj.AddComponent(loadSystemSetting[i].loadSystemTypes[j].GetClass()) as System);
                            Debug.Log("yhyh: Add Component: " + systemObj.name);
                        }
                    }
                    //卸载无需加载的System
                    for (int k = SystemManager.SystemList.Count-1; k >= 0; --k)
                    {
                        //存在原本有，后续没有，需删除
                        if (!loadSystemSetting[i].loadSystemTypes.Exists(type =>
                                type.GetClass() == SystemManager.SystemList[k].GetType()))
                        {
                            Debug.Log("yhyh: Remove Component: " + SystemManager.SystemList[k].gameObject.name);
                            Destroy(SystemManager.SystemList[k].gameObject);
                            SystemManager.SystemList.RemoveAt(k);
                        }
                    }
                }
            }
        }
        
        public void OnGameRun()
        {
            
        }

        public void OnGameExit()
        {
            
        }

        private void CreateSystemManager()
        {

        }

        private void InitSystemManager()
        {
            
        }
        
        public System CreateSystem(string assetsName, Transform parent)
        {
            GameObject obj = null;
            if (!string.IsNullOrEmpty(assetsName))
            {
                obj = Addressables.InstantiateAsync(assetsName, parent).WaitForCompletion().gameObject;
            }
            return obj?.GetComponent<System>().SystemInit();
        }
        public System FindSystem(string systemName)
        {
            GameObject obj = GameObject.Find(systemName);
            if(obj!=null)
                return obj.GetComponent<System>();
            else
                return null;
        }
    }
}

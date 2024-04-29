using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public enum MoudelType
    {
        UI,
        Player,
        Enemy,
        Resource,
        NULL,
    }

    public enum LogType
    {
        Common,
        Warning,
        Error
    }

    public class LogSystem:System,ISystem
    {
        [SerializeField][Header("屏蔽Log")]private List<MoudelType> ignoreMoudelTypes;
        
        public void Log(MoudelType type,string message,LogType logType)
        {
            if (!ignoreMoudelTypes.Contains(type))
            {
                switch (logType)
                {
                    case LogType.Common : Debug.unityLogger.Log(message); break; 
                    case LogType.Warning : Debug.unityLogger.Log(message); break;
                    case LogType.Error : Debug.unityLogger.Log(message); break;
                }
            }
        }

        public override void ManagerInit()
        {
            
        }
        
        public override void SystemDestroy()
        {
            Destroy(gameObject);
        }
    }
}
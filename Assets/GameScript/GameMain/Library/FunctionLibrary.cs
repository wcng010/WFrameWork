using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Wcng
{
    public static class FunctionLibrary
    {
        public static bool Compare(string str1, string str2)
        {
            return String.Compare(str1, str2, StringComparison.Ordinal) == 0;
        }
        
        public static Vector3 ConvertMoveInputToCameraSpace(Transform cameraTransform, float horz, float vert)
        {
            float moveX = (horz * cameraTransform.right.x) + (vert * cameraTransform.forward.x);
            float moveZ = (horz * cameraTransform.right.z) + (vert * cameraTransform.forward.z);
            return new Vector3(moveX, 0f, moveZ);
        }

        public static void GetFiles(string path)
        {
            //string path = string.Format("{0}", @"C:\Users\USER\Desktop\JXBWG\Assets\StreamingAssets");

            //获取指定路径下面的所有资源文件  
            if (Directory.Exists(path))
            {
                DirectoryInfo direction = new DirectoryInfo(path);
                FileInfo[] files = direction.GetFiles("*");
                for (int i = 0; i < files.Length; i++)
                {
                    //忽略关联文件
                    if (files[i].Name.EndsWith(".meta"))
                    {
                        continue;
                    }
                    Debug.Log("文件名:" + files[i].Name);
                    Debug.Log("文件绝对路径:" + files[i].FullName);
                    Debug.Log("文件所在目录:" + files[i].DirectoryName);
                }
            }
        }
        
        public static Type GetTypeByName(string name)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.Name == name)
                        return type;
                }
            }

            return null;
        }
        
        public static T GetTypeInList<T> (List<T> list, Type type)
        {
            int index = list.FindIndex((component) => component.GetType() == type);
            if (index < 0)
            {
                Debug.LogWarning(String.Format("{0} does not exist", type));
            }
            return index >= 0 ? list[index] : default;
        }
    }
}
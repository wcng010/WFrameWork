using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Wcng
{
    public static class CommonFunc
    {
        public static void InvokeDelayVoid(MonoBehaviour T,string methodName,float during) => T.Invoke(methodName,during);
        
        public static string GetMemory(object obj)
        {
            GCHandle handle = GCHandle.Alloc(obj, GCHandleType.WeakTrackResurrection);
            IntPtr addr = GCHandle.ToIntPtr(handle);
            return $"0x{addr.ToString("X")}";
        }
    }
}
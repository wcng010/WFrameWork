using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Wcng
{
    [Serializable]
    public class ResourceDictionary 
    {
        [SerializeField] private List<string> assetsName = new List<string>();
        [SerializeField] private List<AssetReference> assetReferences = new List<AssetReference>();
        public int Count
        {
            get => assetsName.Count ;
            private set { }
        }

        public string GetKey(int index)
        {
            if (index < Count)
            {
                return assetsName[index];
            }
            Debug.LogError("数组越界");
            return null;
        }

        public AssetReference GetValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return assetReferences[assetsName.IndexOf(name)];
            }
            return null;
        }
    }
}
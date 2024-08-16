using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    [CreateAssetMenu(fileName = "SceneSystemSo",menuName = "Data/SceneSystemSo")]
    public class SceneSystemSo : ScriptableObject
    {
        public int levelIndex ;
        //public List<string> loadSystemNames = new List<string>();
        [SerializeField] public List<MonoScript> loadSystemTypes = new List<MonoScript>();
    }
}
 
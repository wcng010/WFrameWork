using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    [CreateAssetMenu(fileName = "SceneSystemSo",menuName = "Data/SceneSystemSo")]
    public class SceneSystemSo : ScriptableObject
    {
        public int levelIndex ;
        public List<string> loadSystemNames = new List<string>();
    }
}
 
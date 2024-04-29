using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    [Serializable]
    public struct SceneTreeNode
    {
        public SceneType sceneType;
        [Range(1,20)]public int high;
        [Range(1,8)]public int weight;
        public List<SceneTreeParentNode> parentNodes;
    }

    [Serializable]
    public struct SceneTreeParentNode
    {
        [Range(1,20)]public int high;
        [Range(1,8)]public int weight;
    }

    [CreateAssetMenu(fileName = "SceneSetting",menuName = "Data/SceneSetting")]
    public class SceneSetting : EntityData
    {
        public int currentLevelTreeHigh;
        public List<int> currentLevelTreeWeight;
        public int maxLevelTreeHigh;
        public List<SceneTreeNode> sceneTree = new List<SceneTreeNode>();
        public override void ReSet()
        {
            currentLevelTreeHigh = maxLevelTreeHigh;
            currentLevelTreeWeight = new List<int> { 1, 2, 3, 4 };
        }
    }
}

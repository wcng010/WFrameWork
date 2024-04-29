using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Wcng;

namespace Wcng
{
    public class SceneMenu : MonoBehaviour
    {
        [SerializeField] private SceneSetting sceneSetting;
        [SerializeField] private List<SceneMenuButton> sceneMenuButtons = new List<SceneMenuButton>();

        private void Start()
        {
            sceneMenuButtons = new List<SceneMenuButton>(transform.GetComponentsInChildren<SceneMenuButton>());
            //更新可点击节点
            CreateLevelTree();
            OpenLevelTreeButton();
        }

        public void CreateLevelTree()
        {
            sceneMenuButtons.Clear();
            int high = 1;
            while (high <= sceneSetting.maxLevelTreeHigh)
            {
                //遍历节点队列
                List<SceneTreeNode> nodes = new List<SceneTreeNode>();
                for (int i = 0; i < sceneSetting.sceneTree.Count; ++i)
                {
                    //找到同一高度的所有节点
                    if (sceneSetting.sceneTree[i].high == high)
                    {
                        nodes.Add(sceneSetting.sceneTree[i]);
                    }
                }
                int startY = 400 - 1080 / sceneSetting.maxLevelTreeHigh * (high - 1);
                //奇数
                if (nodes.Count % 2 == 1)
                {
                    GameObject node =SystemManager.ResourceSystem.CreatePrefab("SceneTreeNode", transform, ResourceType.MoreTime);
                    sceneMenuButtons.Add(node.GetComponent<SceneMenuButton>().SetMessage(nodes[nodes.Count/2]));
                    node.GetComponent<RectTransform>().localPosition = new Vector3(0, startY);
                }
                if (nodes.Count != 1)
                {
                    for (int i = 0, startX = (nodes.Count / 2 + high - 1) * (-120);
                         i < nodes.Count / 2;
                         ++i, startX += 480)
                    {
                        GameObject node =
                            SystemManager.ResourceSystem.CreatePrefab("SceneTreeNode", transform,
                                ResourceType.MoreTime);
                        sceneMenuButtons.Add(node.GetComponent<SceneMenuButton>().SetMessage(nodes[i]));
                        node.GetComponent<RectTransform>().localPosition = new Vector3(startX, startY);
                    }

                    for (int j = nodes.Count - 1, startX = (nodes.Count / 2 + high - 1) * 120;
                         j >= nodes.Count / 2 && nodes.Count%2 != 1;
                         --j, startX -= 480)
                    {
                        GameObject node =
                            SystemManager.ResourceSystem.CreatePrefab("SceneTreeNode", transform,
                                ResourceType.MoreTime);
                        sceneMenuButtons.Add(node.GetComponent<SceneMenuButton>().SetMessage(nodes[j]));
                        node.GetComponent<RectTransform>().localPosition = new Vector3(startX, startY);
                    }
                }
                ++high;
            }
        }


        public void OpenLevelTreeButton()
        { 
            for (int i = 0; i < sceneMenuButtons.Count; ++i)
            {
                if (sceneMenuButtons[i].node.high == sceneSetting.currentLevelTreeHigh 
                   && sceneSetting.currentLevelTreeWeight.Contains(sceneMenuButtons[i].node.weight))
                {
                    sceneMenuButtons[i].Button.enabled = true;
                    sceneMenuButtons[i].Outline.enabled = true;
                }
            }
        }

        public void SaveLevelTreePos(List<SceneTreeParentNode> nodes)
        {
            sceneSetting.currentLevelTreeHigh = nodes[0].high;
            for (int i = 0; i < nodes.Count; ++i)
            {
                sceneSetting.currentLevelTreeWeight.Add(nodes[i].weight);
            }
        }
        
    }
}

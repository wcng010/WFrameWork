using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Wcng
{
    [Serializable]
    public enum SceneType
    {
        ShopScene = 3,
        ChoiceScene = 4,
        EnemyScene = 2,
        BossScene = 5,
    }
    
    public class SceneMenuButton : MonoBehaviour
    {
        public SceneMenu SceneMenu => _sceneMenu ? _sceneMenu : _sceneMenu = GetComponentInParent<SceneMenu>();
        private SceneMenu _sceneMenu;
        public Button Button => _button? _button: _button = GetComponent<Button>();
        private Button _button;
        public Outline Outline => _outline? _outline: _outline = GetComponent<Outline>();
        private Outline _outline;
        public SceneTreeNode node;
        public void EnterNextChoice()
        {
            SceneMenu.SaveLevelTreePos(node.parentNodes);
            SceneManager.LoadSceneAsync((int)node.sceneType);
        }

        private void Awake()
        {
            Button.onClick.AddListener(EnterNextChoice);
        }

        public SceneMenuButton SetMessage(SceneTreeNode treeNode)
        {
            node = treeNode;
            return this;
        }
    }
}
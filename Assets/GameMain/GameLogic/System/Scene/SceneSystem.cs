using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class SceneSystem : System,ISystem
    {
        [NonSerialized] public EnvironmentManager environmentManager;

        public override System SystemInit()
        {
            ManagerInit();
            return base.SystemInit();
        }

        public override void SystemDestroy()
        {
            environmentManager?.OnManagerDestroy();
            Destroy(gameObject);
        }

        public override void ManagerInit()
        {
            environmentManager?.OnManagerInit();
        }

        public void OnEnable()
        {

        }

        private void LoadChoiceScene() => SceneManager.LoadSceneAsync(1);
        public void LoadChoiceSceneAwait() => Invoke(nameof(LoadChoiceScene),2f);
        
    }
}

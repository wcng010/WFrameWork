using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class EnvironmentManager : Manager,IManager
    {
        public override void OnManagerInit()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public override void OnManagerDestroy()
        {
           
        }
        public override void OnManagerOpen()
        {
            
        }
        public override void OnManagerClose()
        {
            
        }
        public void LoadScene(int levelNum)
        {
            switch (levelNum)
            {
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                default: break;
            }
        }
    }
}

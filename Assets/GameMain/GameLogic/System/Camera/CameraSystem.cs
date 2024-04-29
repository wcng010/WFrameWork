using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class CameraSystem : System,ISystem
    {
        public PlayerCamera playerCamera;
        
        public override void SystemDestroy()
        {
            Destroy(playerCamera);
            base.SystemDestroy();
        }

        public override void ManagerInit()
        {
            
        }
    }
}

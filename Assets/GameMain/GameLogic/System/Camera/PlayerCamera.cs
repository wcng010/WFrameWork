using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField]private Vector2 cameraOffSet;
        private Transform _playerTransform;
        
        private void LateUpdate()
        {
            if(_playerTransform)
                transform.position = new Vector3(_playerTransform.position.x + cameraOffSet.x,_playerTransform.position.y + cameraOffSet.y,-10);
        }

        public void SetPlayerTrans(Transform myTransform)
        {
            _playerTransform = myTransform;
        }
    }
}
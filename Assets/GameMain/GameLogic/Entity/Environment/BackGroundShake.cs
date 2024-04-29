using UnityEngine;

namespace Wcng
{
    public class BackGroundShake : MonoBehaviour
    {
        [SerializeField]private Vector2 shakeAmount;
        private Transform _playerTransform;
        private Vector3 _lastframeCamera = Vector3.zero;
        private void LateUpdate()
        {
            if (_playerTransform)
            {
                if (_lastframeCamera != Vector3.zero)
                {
                    Vector3 shakeMove = Camera.main.transform.position - _lastframeCamera;
                    transform.position -= new Vector3(shakeMove.x * shakeAmount.x, shakeMove.y * shakeAmount.y, 0);
                }
                _lastframeCamera = Camera.main.transform.position;
            }
        }

        public void SetPlayerTrans(Transform myTransform) => _playerTransform = myTransform;

    }
}

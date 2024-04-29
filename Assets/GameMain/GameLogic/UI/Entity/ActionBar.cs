using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Wcng
{
    public class ActionBar : MonoBehaviour
    {
        private Image _image;
        [SerializeField]private int invokeTime;
        [SerializeField]private int invokeTimeMax;

        public void OnOpen()
        {
            gameObject.SetActive(true);
            RecoverAction();
        }

        public void RecoverAction()
        {
            invokeTime = 0;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        public bool UpdateAction(bool isInvoke)
        {
            if (isActiveAndEnabled == false) 
                return true;
            if(isInvoke)
                ++invokeTime;
            if (invokeTime > invokeTimeMax) return false;
            _image.fillAmount = (invokeTimeMax - invokeTime) / (float)invokeTimeMax;
            return true;
        }
    }
}

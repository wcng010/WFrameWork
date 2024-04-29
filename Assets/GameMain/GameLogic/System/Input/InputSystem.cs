using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Wcng
{
    public class InputSystem : System,ISystem
    {
        private PlayerInput PlayerInput => _playerInput? _playerInput : _playerInput = GetComponent<PlayerInput>();
        private PlayerInput _playerInput;
        
        #region Bool
        public int HorizontalInput { get; private set; }
        public int VerticalInput { get; private set; }
        public bool InputA { get; private set; }
        public bool InputD { get; private set; }
        public bool InputS { get; private set; }
        public bool InputSpace { get; private set; }
        public bool InputQ { get; private set; }
        public bool InputJ { get; set; }
        public bool InputK { get; private set; }
        public bool Alpha1 { get; private set; }
        public bool Alpha2 { get; private set; }
        public bool InputE { get; private set; }
        public bool InputEsc { get; private set; }
        public bool InputP { get; private set; }
        public bool InputTap { get; private set; }
        
        #endregion
        
        #region Event
        public void CloseInput() => PlayerInput.enabled = false;
        public void OpenInput() => PlayerInput.enabled = true;
        [NonSerialized] public UnityEvent KeyEventQ = new ();

        [NonSerialized] public UnityEvent KeyEventAlpha1 = new ();

        [NonSerialized] public UnityEvent KeyEventAlpha2 = new();

        [NonSerialized] public UnityEvent KeyEventE = new();

        [NonSerialized] public UnityEvent KeyEventEsc = new();

        [NonSerialized] public UnityEvent KeyEventP = new();

        [NonSerialized] public UnityEvent KeyEventTap = new();
        #endregion
        
        #region UnityEvent
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            var rawMovementInput = context.ReadValue<Vector2>();
            HorizontalInput = Mathf.RoundToInt(rawMovementInput.x);
            VerticalInput = Mathf.RoundToInt(rawMovementInput.y);
        }
        public void OnInput_A(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputA = true;
            }
            if (context.canceled)
            {
                InputA = false;
            }
        }
        public void OnInput_D(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputD = true;
            } 
            if (context.canceled)
            {
                InputD = false;
            }
        }
        public void OnInput_S(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputS = true;
            } 
            if (context.canceled)
            {
                InputS = false;
            }
        }
        public void OnInput_Space(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputSpace = true;
            }

            if (context.canceled)
            {
                InputSpace = false;
            }
        }
        public void OnInput_Q(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputQ = true;
                KeyEventQ?.Invoke();
            } 
            if (context.canceled)
            {
                InputQ = false;
            }
        }
        public void OnInput_J(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputJ = true;
            } 
            if (context.canceled)
            {
                InputJ = false;
            }
        }
        public void OnInput_K(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputK = true;
            } 
            if (context.canceled)
            {
                InputK = false;
            }
        }
        public void OnInput_Alpha1(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Alpha1 = true;
                KeyEventAlpha1?.Invoke();
            }
            if (context.canceled)
            {
                Alpha1 = false;
            }
        }
        public void OnInput_Alpha2(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Alpha2 = true;
                KeyEventAlpha2?.Invoke();
            }
            if (context.canceled)
            {
                Alpha2 = false;
            }
        }
        public void OnInput_E(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputE = true;
                KeyEventE?.Invoke();
            }
            if (context.canceled)
            {
                InputE = false;
            }
        }
        public void OnInput_Esc(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputEsc = true;
                KeyEventEsc?.Invoke();
            }
            if (context.canceled)
            {
                InputEsc = false;
            }
        }
        public void OnInput_P(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputP = true;
                KeyEventP?.Invoke();
            }
            if (context.canceled)
            {
                InputP = false;
            }
        }
        public void OnInput_Tap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                InputTap = true;
                KeyEventTap?.Invoke();
            }

            if (context.canceled)
            {
                InputTap = false;
            }
        }
        #endregion

        public override void ManagerInit()
        {
            
        }
        
        public override void SystemDestroy()
        {
            Destroy(gameObject);
        }
    }
}

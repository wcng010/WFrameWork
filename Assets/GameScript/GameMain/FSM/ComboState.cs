using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using GameScript.GameMain.Component;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Wcng;
using Wcng.Library;

namespace Wcng.FSM
{
    [Serializable] [CreateAssetMenu(fileName = "ComboState",menuName = "Data/State/ComboState")]
    public class ComboState : CharacterState
    {
        private bool _isCombo;
        private Coroutine _currentCoroutine;
        public override void OnEnter()
        {
            _isCombo = false;
            Director.Play(timelineAsset);
        }
        public override void OnPhysicUpdate()
        {
            
        }
        public override void OnLogicUpdate()
        {
            
        }
        
        public override void OnExit()
        {
            base.OnExit();
        }

        public void OpenInputBuffer()
        {
            _currentCoroutine = Controller.StartCoroutine(ComboStateInputBuffer());
        }

        //循环检测输入
        private IEnumerator ComboStateInputBuffer()
        {
            while (true)
            {
                if (InputComponent.GetPressedKeys().Contains(InputKey.MouseClickLeft))
                {
                    _isCombo = true;
                }
                yield return null;
            }
        }

        public void OnAttack()
        {
            //缓冲触发时没有连击
            if (!_isCombo)
            {
                StateMachine.BackLastState();
            }
            Controller.StopCoroutine(_currentCoroutine);
            _isCombo = false;
        }

        public void BackLastState() => StateMachine.BackLastState();


        public void CheckAndAttack()
        {
            DamageComponent.RangeDetection(BodyPoint.Forward,"Enemy", (colliders) =>
            {
                for (int i = 0; i < colliders.Length; ++i)
                {
                    colliders[i].GetComponentInChildren<BloodComponent>().SetHealthMessage(0.8f, BarType.Health);
                }
            });
        }
    }
}

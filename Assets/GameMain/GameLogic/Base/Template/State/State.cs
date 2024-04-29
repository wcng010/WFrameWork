using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wcng
{
    public abstract class State<T> where T : PhysicEntity<T>
    {
        protected readonly T Owner;
        public State(T owner,string nameToTrigger,string animationName)
        {
            Owner = owner;
            NameToTrigger = nameToTrigger;
            AnimationName = animationName;
        }

        #region AnimationValue
        
        protected float AnimationTime;
        
        protected bool IsAnimationName;

        protected bool IsAniamtionFinshed;

        protected readonly string AnimationName;

        protected readonly string NameToTrigger;
        
        #endregion

        #region Component
        protected Transform TransformOwner => Owner.OwnerTransform;

        protected Transform TransformTarget => Owner.TargetTransform;
        protected Rigidbody2D Rigidbody2DOwner => Owner.Rigidbody2D;
        protected Animator AnimatorOwner => Owner.Animator;
        protected Collider2D Collider2DOwner => Owner.Collider2D;
        protected StateMachine<T> StateMachine => Owner.StateMachine;
        protected Dictionary<StateType, State<T>> StateDic => Owner.StateDic;
        protected EntityData DataSo => Owner.entityData;

        #endregion
        
        #region StateProcedure

        public virtual void Enter()
        {
            if (NameToTrigger != null)
            {
                AnimationEnter();
            }
        }
        public virtual void PhysicExcute()
        {
            
        }
        public virtual void LogicExcute()
        {
            
        }
        public virtual void Exit()
        {
            if (NameToTrigger != null)
            {
                AnimatorOwner.SetBool(NameToTrigger, false);
            }
        }
        
        #endregion

        #region AnimationProcedure


        protected virtual void AnimationEnter()
        {
            Owner.StartCoroutine(CheckAnimationState(AnimatorOwner, AnimationName));
        }
        
        protected virtual void AnimationExcute()
        {
            
        }

        protected virtual void AnimationExit()
        {
            StateMachine.RevertOrinalState();
        }
        
        /// <summary>
        /// 检测动画播放情况
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="animationName"></param>
        /// <param name="layerIndex"></param>
        /// <returns></returns>
        protected IEnumerator CheckAnimationState(Animator animator, string animationName,int layerIndex = 0)
        {
            IsAniamtionFinshed = false;
            IsAnimationName = false;
            AnimatorOwner.SetBool(NameToTrigger, true);
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(animationName));
            IsAnimationName = true;
            AnimationTime = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= 0.98f);
            IsAniamtionFinshed = true;
            AnimationExit();
        }
        
        /// <summary>
        /// 检测是否为当前State
        /// </summary>
        /// <returns></returns>
        protected bool CheckCurrentState()
        {
            if (!Equals(StateMachine.CurrentState, this))
                return false;
            return true;
        }


        private IEnumerator ActionDuringAnimation(Action action,float animationRate ,int layerIndex = 0)
        {
            yield return new WaitUntil(() => AnimatorOwner.GetCurrentAnimatorStateInfo(layerIndex).IsName(AnimationName));
            yield return new WaitUntil(() =>
                AnimatorOwner.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= animationRate);
            action.Invoke();
        }

        protected void ActionPlayDuringAnimation(Action action, float animationRate ,int layerIndex = 0)
        {
            Owner.StartCoroutine(ActionDuringAnimation(action, animationRate,
                layerIndex));
        }

        #endregion

        protected void ChangeState(StateType stateType)
        {
            StateMachine.ChangeState(StateDic[stateType]);
        }

        
        
        protected void StartCoroutine(UnityAction action,float duration)
        {
            Owner.StartCoroutine(WaitForCoroutine(action, duration));
        }

        private IEnumerator WaitForCoroutine(UnityAction action, float duration)
        {
            yield return new WaitForSeconds(duration);
            action.Invoke();
        }

        protected R GetCoreComponent<R>() where R : CoreComponent
        {
            return Owner.GetCoreComponent<R>();
        }
    }
}


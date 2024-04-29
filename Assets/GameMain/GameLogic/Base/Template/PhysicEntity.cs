using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Wcng
{
    //离线物理实体
    public abstract class PhysicEntity<T> :DataEntity where T :PhysicEntity<T>
    {
        
        public bool isOnline;
        [field: SerializeField] private EntityCore entityCore;
        public Transform OwnerTransform { get; private set; }
        public Transform TargetTransform { get; protected set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Animator Animator { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public Collider2D Collider2D { get; private set; }
        public StateMachine<T> StateMachine{ get; protected set; }
        public Dictionary<StateType, State<T>> StateDic { get; protected set; }

        //状态字典
        protected abstract void InitStateDictionary();
        //物理步
        public virtual void PhysicBehaviour()
        {
            StateMachine.StatePhysicBehaviour();
        }
        //逻辑步
        public virtual void LogicBehaviour()
        {
            StateMachine.StateLogicBehaviour();
        }

        #region InitFunction

        protected void InitTransform(Transform otf) => OwnerTransform = otf;
        protected void InitTargetTransform(Transform ttf) => TargetTransform = ttf;
        protected void InitAnimator(Animator at)=>Animator = at;
        protected void InitRigidbody2D(Rigidbody2D rb) => Rigidbody2D = rb;
        protected void InitCollider2D(Collider2D cd) => Collider2D = cd;
        protected void InitSpriteRenderer(SpriteRenderer sR) => SpriteRenderer = sR;
        
        #endregion

        protected virtual void Start()
        {
            InitStateDictionary();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.StatePhysicBehaviour();
        }

        protected virtual void Update()
        {
            StateMachine.StateLogicBehaviour();
        }
        
        protected void ChangeState(StateType stateType)
        {
            if(StateMachine.CurrentState != StateDic[stateType])
                StateMachine.ChangeState(StateDic[stateType]);
        }
        public R GetCoreComponent<R>() where R : CoreComponent
        {
            return entityCore.GetCoreComponent<R>();
        }
        
    }
    //在线物理实体
}

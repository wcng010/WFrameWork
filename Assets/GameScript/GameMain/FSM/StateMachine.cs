using System.Collections.Generic;
using Animancer;
using GameScript.GameMain.Component;
using UnityEngine;
using UnityEngine.Playables;

namespace Wcng.FSM
{
    public abstract class StateMachine<TState> : IStateMachine where TState : class, IState
    {
        protected List<IComponent> Components;
        private TState _originalState;
        public TState OriginalState 
        {
            get
            {
                if (_originalState == null) return null;
                if (!_StateList.Contains(_originalState))
                {
                    _originalState.OnInit(this,AnimancerComponent, Components,PlayableDirector);
                    _StateList.Add(_originalState);
                }
                return _originalState;
            }
            set => _originalState = value;
        }
        object IStateMachine.OriginalState => OriginalState;

        
        private TState _currentState;
        public TState CurrentState
        {
            get
            {
                if (_currentState == null) return null;
                if (!_StateList.Contains(_currentState))
                {
                    _currentState.OnInit(this,AnimancerComponent, Components,PlayableDirector);
                    _StateList.Add(_currentState);
                }
                return _currentState;
            }
            set => _currentState = value;
        }
        object IStateMachine.CurrentState => CurrentState;
        
        private TState _previousState;
        public TState PreviousState
        {
            get
            {
                if (_previousState == null) return null;
                if (!_StateList.Contains(_previousState))
                {
                    _previousState.OnInit(this,AnimancerComponent, Components,PlayableDirector);
                    _StateList.Add(_previousState);
                }
                return _previousState;
            }
            set => _previousState = value;
        }
        object IStateMachine.PreviousState => PreviousState;
        
        protected AnimancerComponent AnimancerComponent;
        protected PlayableDirector PlayableDirector;
        
        private readonly List<IState> _StateList = new List<IState>();
        
        public void ChangeState(object state)
        {
            TState stateTemp = state as TState;
            if (!_StateList.Contains(stateTemp))
            {
                stateTemp?.OnInit(this,AnimancerComponent, Components,PlayableDirector);
                _StateList.Add(stateTemp);
            }
            if (CurrentState == null)
            {
                stateTemp?.OnEnter();
                CurrentState = stateTemp;
            }
            else if (stateTemp != CurrentState && CurrentState.CanChangeState)
            {
                CurrentState?.OnExit(); 
                stateTemp?.OnEnter();
                PreviousState = CurrentState; 
                CurrentState = stateTemp;
            }
        }

        public void LogicUpdate()
        {
            CurrentState.OnLogicUpdate();
        }

        public void FixedUpdate()
        {
            CurrentState.OnPhysicUpdate();
        }
        
        public virtual void BackLastState()
        {
            CurrentState?.OnExit();
            PreviousState?.OnEnter();
            (PreviousState, CurrentState) = (CurrentState, PreviousState);
        }

        public virtual void BackOriginalState()
        {
            CurrentState?.OnExit();
            OriginalState?.OnEnter();
            PreviousState = _currentState;
        }
        
    }
}

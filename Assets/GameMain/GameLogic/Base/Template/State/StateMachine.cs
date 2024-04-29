using UnityEngine;

namespace Wcng
{
    public class StateMachine <TOwnerClass> where TOwnerClass : PhysicEntity<TOwnerClass>
    {
        
        private TOwnerClass _stateOwner;
        //状态
        private State<TOwnerClass> _currentState;
        private State<TOwnerClass> _previousState;
        private State<TOwnerClass> _globalState;
        private State<TOwnerClass> _originalState;
        
        public State<TOwnerClass> CurrentState => _currentState;
        public State<TOwnerClass> PreviousState => _previousState;
        public State<TOwnerClass> GlobalState => _globalState;
        public State<TOwnerClass> OriginalState => _originalState;
        
        public StateMachine(TOwnerClass owner)
        {
            _stateOwner = owner;
            _currentState = null;
            _previousState = null;
            _globalState = null;
        }

        public void SetCurrentState(State<TOwnerClass> currentState)
        {
            _currentState = currentState;
            _currentState.Enter();
        }

        public void SetPreviousState(State<TOwnerClass> previousState) => _previousState = previousState;
        public void SetGlobalState(State<TOwnerClass> globalState) => _globalState = globalState;
        public void SetOriginalState(State<TOwnerClass> originalState) => _originalState = originalState;
        
        public void StatePhysicBehaviour()
        {
            if(_globalState!=null) 
                _globalState.PhysicExcute();
            if (_currentState != null)
                _currentState.PhysicExcute();
            else
                Debug.LogError("No CurrentState Playing");
        }


        public void StateLogicBehaviour()
        {
            if(_globalState!=null) 
                _globalState.LogicExcute();
            
            if (_currentState != null)
                _currentState.LogicExcute();
            else 
                Debug.LogError("No CurrentState Playing");
        }

        public void ChangeState(State<TOwnerClass> newState)
        {
            _previousState = _currentState;
            _previousState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        public void RevertState()
        {
            ChangeState(_previousState);
        }

        public void RevertOrinalState()
        {
            ChangeState(OriginalState);
        } 
    }
}


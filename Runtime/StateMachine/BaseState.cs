using System;

namespace CommonSolutions.Runtime.StateMachine
{
    public abstract class BaseState<TStateType> : IState<TStateType> where TStateType : Enum
    {
        public event Action<TStateType, object> StateChangeRequested;
        
        public abstract TStateType StateType { get; }

        public void Enter(TStateType previousState, object args)
        {
            OnEnter(previousState, args);
        }

        protected virtual void OnEnter(TStateType previousState, object args)
        {
        }
        
        public void Exit()
        {
            OnExit();
        }
        
        protected virtual void OnExit()
        {
        }
        
        protected void ChangeState(TStateType newState, object args = null)
        {
            StateChangeRequested?.Invoke(newState, args);
        }
    }
}
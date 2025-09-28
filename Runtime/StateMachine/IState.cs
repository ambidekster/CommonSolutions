using System;

namespace CommonSolutions.Runtime.StateMachine
{
    public interface IState<TStateType> where TStateType : Enum
    {
        event Action<TStateType, object> StateChangeRequested;
        
        TStateType StateType { get; }
        
        void Enter(TStateType previousState, object args);
        void Exit();
    }
}
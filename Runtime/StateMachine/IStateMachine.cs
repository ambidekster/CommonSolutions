using System;

namespace CommonSolutions.Runtime.StateMachine
{
    public interface IStateMachine<TStateType> where TStateType : Enum
    {
        event Action<TStateType, TStateType> StateChanged;
        
        void Start(TStateType defaultState);
        void Reset();
    }
}
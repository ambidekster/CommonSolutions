using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommonSolutions.Runtime.StateMachine
{
    public class StateMachine<TStateType> : IStateMachine<TStateType> where TStateType : Enum
    {
        public event Action<TStateType, TStateType> StateChanged;
        
        private Dictionary<TStateType, IState<TStateType>> _states;

        private IState<TStateType> _currentState;

        public StateMachine(IEnumerable<IState<TStateType>> states)
        {
            _states = states
                    .ToDictionary(s => s.StateType, s => s);
        }

        public void Start(TStateType defaultState)
        {
            ChangeState(defaultState);
        }

        public void Reset()
        {
            if(_currentState != null)
            {
                _currentState.StateChangeRequested -= HandleStateChangeRequested;
                _currentState.Exit();   
                _currentState = null;
            }
            
            _states.Clear();
        }

        private void HandleStateChangeRequested(TStateType stateType, object args)
        {
            ChangeState(stateType, args);
        }

        private void ChangeState(TStateType stateType, object args = null)
        {
            var previousStateType = default(TStateType);
            
            if(_currentState != null)
            {
                previousStateType = _currentState.StateType;
                
                _currentState.StateChangeRequested -= HandleStateChangeRequested;
                _currentState.Exit();
            }

            var newState = GetState(stateType);
            if(newState != null)
            {
                _currentState = newState;
                _currentState.StateChangeRequested += HandleStateChangeRequested;
                _currentState.Enter(previousStateType, args);
                
                StateChanged?.Invoke(previousStateType, newState.StateType);
            }
        }

        private IState<TStateType> GetState(TStateType type)
        {
            if(_states.TryGetValue(type, out var state))
            {
                return state;
            }

            Debug.LogError($"Invalid game state type: {type}");
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonSolutions.Runtime.Events.Dispatcher
{
    public class EventsDispatcher : IEventsDispatcher
    {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new();

        public void Subscribe<T>(Action<T> handler) 
        {
            var eventType = typeof(T);
            if(!_handlers.ContainsKey(eventType))
            {
                _handlers.Add(eventType, new List<Delegate>());
            }
            
            _handlers[eventType].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler) 
        {
            var eventType = typeof(T);
            if(!_handlers.ContainsKey(eventType))
            {
                Debug.LogError($"Action with type: {eventType} doesn't exist");
                return;
            }

            _handlers[eventType].Remove(handler);
        }

        public void Dispatch<T>(T args) 
        {
            var eventType = args.GetType();
            if(!_handlers.ContainsKey(eventType))
            {
                return;
            }
            
            var actions = _handlers[eventType];
            for(var i = 0; i < actions.Count; i++)
            {
                actions[i].Method.Invoke(actions[i].Target, new object[] { args });
            }
        }
    }
}
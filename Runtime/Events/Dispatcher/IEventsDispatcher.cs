using System;

namespace CommonSolutions.Runtime.Events.Dispatcher
{
    public interface IEventsDispatcher
    {
        void Subscribe<T>(Action<T> handler);
        void Unsubscribe<T>(Action<T> handler);
        void Dispatch<T>(T args);
    }
}
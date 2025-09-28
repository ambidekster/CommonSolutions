using System;

namespace CommonSolutions.Runtime.Events.Raiser
{
    public interface IEventsRaiser<TEvent> where TEvent : Enum
    {
        event Action<TEvent, EventArgs> EventRaised;
        
        void Raise(TEvent e, EventArgs args);
    }
}
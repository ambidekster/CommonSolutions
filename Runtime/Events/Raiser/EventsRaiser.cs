using System;

namespace CommonSolutions.Runtime.Events.Raiser
{
    public class EventsRaiser<TEvent> : IEventsRaiser<TEvent> 
            where TEvent : Enum
    {
        public event Action<TEvent, EventArgs> EventRaised;
        
        public void Raise(TEvent e, EventArgs args)
        {
            EventRaised?.Invoke(e, args);
        }
    }
}
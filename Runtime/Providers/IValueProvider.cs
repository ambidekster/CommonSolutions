using System;

namespace CommonSolutions.Runtime.Providers
{
    public interface IValueProvider<TValue>
    {
        event Action<TValue> Changed;
        
        TValue Value { get; set; }
    }
}
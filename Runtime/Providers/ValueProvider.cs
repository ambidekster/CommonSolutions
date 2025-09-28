using System;

namespace CommonSolutions.Runtime.Providers
{
    public class ValueProvider<TValue> : IValueProvider<TValue>
    {
        public event Action<TValue> Changed;
        
        private TValue _value;

        public ValueProvider()
        {
            _value = default(TValue);
        }

        public ValueProvider(TValue value)
        {
            _value = value;
        }

        public TValue Value
        {
            get => _value;
            
            set
            {
                if(_value != null && 
                   _value.Equals(value))
                {
                    return;
                }
                
                _value = value;
                Changed?.Invoke(value);
            }
        }
    }
}
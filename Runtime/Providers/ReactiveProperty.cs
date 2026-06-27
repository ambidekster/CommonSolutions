using System;

namespace CommonSolutions.Runtime.Providers
{
    public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>, IDisposable where T : IEquatable<T>
    {
        private event Action<T> _onValueChanged;
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if(_value != null && _value.Equals(value))
                {
                    return;
                }

                _value = value;
                _onValueChanged?.Invoke(value);
            }
        }

        public ReactiveProperty()
        {
        }

        public ReactiveProperty(T value)
        {
            _value = value;
        }

        public void Subscribe(Action<T> onValueChanged)
        {
            _onValueChanged += onValueChanged;
            onValueChanged?.Invoke(Value);
        }

        public void Unsubscribe(Action<T> onValueChanged)
        {
            _onValueChanged -= onValueChanged;
        }

        void IDisposable.Dispose()
        {
            _onValueChanged = null;
            _value = default(T);
        }
    }
}
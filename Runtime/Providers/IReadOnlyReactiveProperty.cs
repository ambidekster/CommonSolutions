using System;

namespace CommonSolutions.Runtime.Providers
{
    public interface IReadOnlyReactiveProperty<out T> where T : IEquatable<T>
    {
        T Value { get; }

        void Subscribe(Action<T> onValueChanged);
        void Unsubscribe(Action<T> onValueChanged);
    }
}
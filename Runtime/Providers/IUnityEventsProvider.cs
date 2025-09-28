using System;

namespace CommonSolutions.Runtime.Providers
{
    public interface IUnityEventsProvider
    {
        event Action<float> Updated;
        event Action<float> LateUpdated;
        event Action<float> FixedUpdated;
    }
}
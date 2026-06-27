using System;

namespace CommonSolutions.Runtime
{
    public interface IInitializable
    {
        event Action Initialized;

        bool IsInitialized { get; }

        void Initialize();
    }
}
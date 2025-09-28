using System;

namespace CommonSolutions.Runtime.Providers
{
    public interface IRandomProvider
    {
        Random Random { get; }
    }
}
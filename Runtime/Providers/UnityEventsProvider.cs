using System;
using UnityEngine;

namespace CommonSolutions.Runtime.Providers
{
    public class UnityEventsProvider : MonoBehaviour, IUnityEventsProvider
    {
        public event Action<float> Updated;
        public event Action<float> LateUpdated;
        public event Action<float> FixedUpdated;

        private void Update()
        {
            Updated?.Invoke(Time.deltaTime);
        }

        private void LateUpdate()
        {
            LateUpdated?.Invoke(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            FixedUpdated?.Invoke(Time.fixedDeltaTime);
        }
    }
}
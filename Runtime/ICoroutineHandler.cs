using System.Collections;
using UnityEngine;

namespace CommonSolutions.Runtime
{
    public interface ICoroutineHandler
    {
        Coroutine StartCoroutine(IEnumerator routine);
        
        void StopCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}
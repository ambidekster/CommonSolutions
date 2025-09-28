using System.Collections;
using UnityEngine;

namespace CommonSolutions.Runtime
{
    public class CoroutineHandler : MonoBehaviour, ICoroutineHandler
    {
        public Coroutine StartCoroutine(IEnumerator routine)
        {
            if(routine != null)
            {
                return StartCoroutine(routine);
            }

            return null;
        }

        public void StopCoroutine(IEnumerator coroutine)
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
		
        public void StopCoroutine(Coroutine coroutine)
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }
}
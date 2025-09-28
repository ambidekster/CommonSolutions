using UnityEngine;

namespace CommonSolutions.Runtime.Pool
{
    public interface IObjectsPool
    {
        T Instantiate<T>(string prefabPath, Transform parent = null) where T : Object;
        T Instantiate<T>(T obj, Transform parent = null) where T : Object;
        
        void Return<T>(T obj) where T : Object;

        void ClearAll();
        void ClearAll<T>(T obj) where T : Object;
    }
}
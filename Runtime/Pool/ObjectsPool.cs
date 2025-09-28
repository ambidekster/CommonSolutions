using System.Collections.Generic;
using CommonSolutions.Runtime.Extensions;
using UnityEngine;

namespace CommonSolutions.Runtime.Pool
{
    public class ObjectsPool : IObjectsPool
    {
        private readonly GameObject _root;
        
        private readonly Dictionary<int, Stack<Object>> _cache = new Dictionary<int, Stack<Object>>();
        private readonly Dictionary<int, int> _instanceToOriginalMap = new Dictionary<int, int>();

        public ObjectsPool(string id, bool debug = false)
        {
            _root = new GameObject($"ObjectsPool_{id}");
            Object.DontDestroyOnLoad(_root);

            if(!debug)
            {
                _root.hideFlags = HideFlags.HideInHierarchy;
            }
        }

        public T Instantiate<T>(string prefabPath, Transform parent = null) where T : Object
        {
            var source = GetObjectSource(prefabPath);
            if(source == null)
            {
                Debug.LogError($"Invalid prefabPath: {prefabPath}");
                return null;
            }
            
            return InstantiateInternal(source, parent) as T;
        }

        public T Instantiate<T>(T obj, Transform parent = null) where T : Object
        {
            return InstantiateInternal(obj, parent);
        }

        private T InstantiateInternal<T>(T original, Transform parent = null) where T : Object
        {
            var originalId = original.GetInstanceID();
            if(!_cache.ContainsKey(originalId))
            {
                _cache.Add(originalId, new Stack<Object>());
            }
            else
            {
                if(_cache[originalId].Count > 0)
                {
                    var cachedObject = _cache[originalId].Pop() as T;
                    if(cachedObject == null)
                    {
                        Debug.LogError($"Invalid instance for original id: {originalId}");
                        return null;
                    }
                    
                    _instanceToOriginalMap[cachedObject.GetInstanceID()] = originalId;   
                    
                    var gameObject = cachedObject.GameObject();
                    gameObject.transform.SetParent(parent);
                    gameObject.SetActive(true);
                    
                    return cachedObject;   
                }
            }
            
            var newObject = Object.Instantiate(original, parent);
            _instanceToOriginalMap[newObject.GetInstanceID()] = originalId;   
            
            return newObject;
        }

        private GameObject GetObjectSource(string prefabPath)
        {
            return Resources.Load(prefabPath, typeof(GameObject)) as GameObject;
        }
        
        public void Return<T>(T obj) where T : Object
        {
            var instanceId = obj.GetInstanceID();
            if(!_instanceToOriginalMap.ContainsKey(instanceId))
            {
                Debug.LogError($"Can't find cached instance with id: {instanceId}");
                return;
            }
            
            var gameObject = obj.GameObject();
            gameObject.SetActive(false);
            gameObject.transform.SetParent(_root.transform);
            
            var originalId = _instanceToOriginalMap[instanceId];
            _cache[originalId].Push(obj);
            _instanceToOriginalMap.Remove(instanceId);
        }

        public void ClearAll()
        {
            foreach(var id in _cache.Keys)
            {
                ClearAllInternal(id);
            }
        }

        public void ClearAll<T>(T obj) where T : Object
        {
            ClearAllInternal(obj.GetInstanceID());
        }
        
        private void ClearAllInternal(int id)
        {
            if(!_cache.ContainsKey(id))
            {
                Debug.LogError($"Can't find cached instance with id: {id}");
                return;
            }

            while(_cache[id].Count > 0)
            {
                var instance = _cache[id].Pop();
                Object.Destroy(instance.GameObject());
            }
        }
    }
}
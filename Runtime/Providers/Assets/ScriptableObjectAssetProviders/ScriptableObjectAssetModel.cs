using System;
using UnityEngine;

namespace CommonSolutions.Runtime.Providers.Assets.ScriptableObjectAssetProviders
{
    [Serializable]
    public class ScriptableObjectAssetModel<TAsset> 
            where TAsset : UnityEngine.Object
    {
        [SerializeField] private string _id;
        [SerializeField] private TAsset _asset;
        
        public string Id => _id;
        public TAsset Asset => _asset;
    }
}
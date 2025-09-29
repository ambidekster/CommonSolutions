using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommonSolutions.Runtime.Providers.Assets.ScriptableObjectAssetProviders
{
    public abstract class ScriptableObjectAssetProvider<TAsset> : ScriptableObject, IAssetProvider<TAsset>
            where TAsset : UnityEngine.Object
    {
        [SerializeField] private List<ScriptableObjectAssetModel<TAsset>> _models;

        public TAsset GetAsset(string id)
        {
            return GetAssetInternal(id, $"Invalid asset id: {id}");
        }

        public bool TryGetAsset(string id, out TAsset asset)
        {
            asset = GetAssetInternal(id);
            return asset != null;
        }

        private TAsset GetAssetInternal(string id, string notFoundMessage = null)
        {
            var model = _models.FirstOrDefault(a => a.Id == id);
            if(model != null)
            {
                return model.Asset;
            }

            if(!string.IsNullOrEmpty(notFoundMessage))
            {
                Debug.LogError(notFoundMessage);
            }
            
            return null;
        }
    }
}
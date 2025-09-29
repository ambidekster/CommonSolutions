namespace CommonSolutions.Runtime.Providers.Assets
{
    public interface IAssetProvider<TAsset> where TAsset : UnityEngine.Object
    {
        TAsset GetAsset(string id);
        bool TryGetAsset(string id, out TAsset asset);
    }
}
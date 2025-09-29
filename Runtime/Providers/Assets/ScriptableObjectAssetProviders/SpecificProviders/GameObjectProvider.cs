using UnityEngine;

namespace CommonSolutions.Runtime.Providers.Assets.ScriptableObjectAssetProviders.SpecificProviders
{
    [CreateAssetMenu(fileName = "GameObjectProvider", menuName = "ScriptableObjectAssetProviders/GameObjectProvider", order = 1)]
    public class GameObjectProvider : ScriptableObjectAssetProvider<GameObject>
    {
    }
}
using UnityEngine;

namespace CommonSolutions.Runtime.Providers.Assets.SpecificProviders
{
    [CreateAssetMenu(fileName = "GameObjectProvider", menuName = "Providers/GameObjectProvider", order = 1)]
    public class GameObjectProvider : AssetProvider<GameObject>
    {
    }
}
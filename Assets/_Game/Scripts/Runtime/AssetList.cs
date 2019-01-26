using UnityEngine;

namespace Game
{
    
    
    [CreateAssetMenu (menuName = "Game/Asset List")]
    public class AssetList : ScriptableObject
    {
        public Transform[] Assets;

        public Transform GetRandom ()
        {
            return Assets[Random.Range (0, Assets.Length)];
        }
    }

}
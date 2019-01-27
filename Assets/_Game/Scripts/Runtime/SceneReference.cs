using UnityEngine;

namespace Game
{
    [CreateAssetMenu]
    public class SceneReference : ScriptableObject
    {
        public string SceneName;

        public void LoadScene ()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (SceneName);
        }
    }

}
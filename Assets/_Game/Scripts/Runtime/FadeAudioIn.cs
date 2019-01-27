using UnityEngine;

namespace Game
{
    public class FadeAudioIn : MonoBehaviour
    {
        public float FadeInLength;
        public float TargetVolume;

        public AudioSource TargetAudioSource;
        
        private void Update ()
        {
            TargetAudioSource.volume = Mathf.Lerp (0, TargetVolume, Time.deltaTime / FadeInLength);
        }
    }

}
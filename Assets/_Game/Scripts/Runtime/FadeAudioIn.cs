using UnityEngine;

namespace Game
{
    public class FadeAudioIn : MonoBehaviour
    {
        public float FadeInLength;
        public float TargetVolume;

        public AudioSource TargetAudioSource;

        private float startTime;

        private void OnEnable ()
        {
            startTime = Time.time;
            TargetAudioSource.volume = 0;
        }

        private void Update ()
        {
            var timeElapsed = Time.time - startTime;
            TargetAudioSource.volume = Mathf.Lerp (0, TargetVolume, timeElapsed / FadeInLength);

            if (timeElapsed > FadeInLength)
                enabled = false;
        }
    }

}
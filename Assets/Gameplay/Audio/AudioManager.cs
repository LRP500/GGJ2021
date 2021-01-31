using UnityEngine;

namespace Tools.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _soundtrackSource;

        [SerializeField]
        private AudioSource _ambianceSource;

        [SerializeField]
        private float _musicfadeOutDuration;

        public void PlaySoundtrack()
        {
            _ambianceSource.Play();
        }

        public void StopSoundtrack()
        {
            StartCoroutine(AudioUtility.FadeOut(_soundtrackSource, _musicfadeOutDuration));
        }

        public void PlayAmbiance()
        {
            _ambianceSource.Play();
        }
    }
}
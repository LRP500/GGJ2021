using System.Collections.Generic;
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

        [SerializeField]
        private List<AudioSource> _inGameSources;

        public void PlaySoundtrack()
        {
            _soundtrackSource.Play();
        }

        public void StopSoundtrack()
        {
            StartCoroutine(AudioUtility.FadeOut(_soundtrackSource, _musicfadeOutDuration));
        }

        public void PlayAmbiance()
        {
            _ambianceSource.Play();
        }

        public void OnGameStart()
        {
            StopSoundtrack();
            PlayAmbiance();

            foreach (AudioSource source in _inGameSources)
            {
                source.Play();
            }
        }
    }
}
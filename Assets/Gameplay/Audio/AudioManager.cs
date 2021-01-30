using UnityEngine;

namespace Tools.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private SimpleAudioEvent _soundtrack;

        [SerializeField]
        private AudioSource _soundtrackSource;

        private void Awake()
        {
            _soundtrackSource.loop = true;
            _soundtrackSource.spatialBlend = 0;
            _soundtrack.Play(_soundtrackSource);
        }
    }
}

using Tools.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GGJ2021
{
    public class ChildAudio : MonoBehaviour
    {
        [SerializeField]
        private Child _child;

        [SerializeField]
        private SimpleAudioEvent _cryEvent;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private PlayerVariable _player;

        [SerializeField]
        private float _maxDistance;

        [SerializeField]
        [NaughtyAttributes.MinMaxSlider(5, 20)]
        private Vector2 _intervalRange;

        private float _timer;
        private float _interval;

        private void Awake()
        {
            Reset();
        }

        private void Update()
        {
            if (IsNearPlayer())
            {
                _timer += Time.deltaTime;

                if (_timer >= _interval)
                {
                    Play();
                }
            }
        }

        private void Play()
        {
            _cryEvent.Play(_audioSource);
            Reset();
        }

        private void Reset()
        {
            _timer = 0;
            _interval = Random.Range(_intervalRange.x, _intervalRange.y);
        }

        private bool IsNearPlayer()
        {
            return Vector3.Distance(transform.position, _player.Value.transform.position) <= _maxDistance;
        }
    }
}

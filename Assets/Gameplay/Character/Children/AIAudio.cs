using Tools.Audio;
using UnityEngine;
using Random = UnityEngine.Random;
namespace GGJ2021
{
    public class AIAudio : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        [SerializeField]
        private SimpleAudioEvent _cryEvent;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private PlayerVariable _player;

        [SerializeField]
        private float _maxDistance;

        [SerializeField]
        [NaughtyAttributes.MinMaxSlider(2, 15)]
        private Vector2 _intervalRange;

        [SerializeField]
        private bool _emitOnFollow = false;

        private float _timer;
        private float _interval;

        private void Awake()
        {
            Reset();
        }

        private void Update()
        {
            if (_character.Following && !_emitOnFollow)
            {
                return;
            }

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

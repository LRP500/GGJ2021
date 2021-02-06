using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Tools.Audio
{
    public class SimpleAudioEventPlayer : MonoBehaviour
    {
        [SerializeField]
        private SimpleAudioEvent _audioEvent;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private bool _playOnStart;

        [SerializeField]
        private bool _loop;

        [SerializeField]
        [HideIf(nameof(_loop))]
        private bool _repeat;

        [SerializeField]
        [MinMaxSlider(0, 100)]
        [ShowIf(nameof(_repeat))]
        private Vector2 _intervalRange = new Vector2(2f, 5f);

        private float _elapsed = float.MaxValue;
        private float _interval = 0;

        private Coroutine _playRepeat;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _audioSource.loop = _loop;
            _audioSource.playOnAwake = false;
        }

        private void Start()
        {
            if (_playOnStart)
            {
                Play();   
            }
        }

        public void Play()
        {
            if (_repeat && _playRepeat == null)
            {
                _playRepeat = StartCoroutine(PlayRepeat());
            }
            else
            {
                PlaySingle();
            }
        }

        public void Stop()
        { 
            if (_playRepeat != null)
            {
                StopCoroutine(_playRepeat);
            }
        }

        private IEnumerator PlayRepeat()
        {
            Reset();

            while (enabled)
            {
                _elapsed += Time.deltaTime;
                
                if (_elapsed >= _interval)
                {
                    PlaySingle();
                    Reset();
                }

                yield return null;
            }

            PlaySingle();
        }

        private void Reset()
        {
            _elapsed = 0;
            _interval = UnityEngine.Random.Range(_intervalRange.x, _intervalRange.y);
        }

        private void PlaySingle()
        {
            _audioEvent.Play(_audioSource);
        }
    }
}

using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace Tools.Audio
{
    [CreateAssetMenu(menuName = "Tools/Audio/Simple Event")]
    public class SimpleAudioEvent : AudioEvent
    {
        public AudioClip[] _clips;

        [MinMaxSlider(0, 1)]
        public Vector2 _volume =  Vector2.one;

        [MinMaxSlider(0, 3)]
        public Vector2 _pitch = Vector2.one;

        private AudioSource _previewer;

        private void Awake()
        {
    #if UNITY_EDITOR
            _previewer = EditorUtility.CreateGameObjectWithHideFlags(
                "Audio preview", HideFlags.HideAndDontSave,
                typeof(AudioSource)).GetComponent<AudioSource>();
    #endif
        }

        public override void Play(AudioSource source)
        {
            if (_clips.Length == 0) return;

            source.clip = _clips[UnityEngine.Random.Range(0, _clips.Length)];
            source.volume = UnityEngine.Random.Range(_volume.x, _volume.y);
            source.pitch = UnityEngine.Random.Range(_pitch.x, _pitch.y);

            if (source.isActiveAndEnabled)
            {
                source.Play();
            }
        }

        [Button]
        private void Preview()
        {
            Play(_previewer);
        }
    }
}

using Tools.Audio;
using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private IntVariable _childrenSavedCount;

        [SerializeField]
        private PlayerVariable _player;

        [SerializeField]
        private AudioManager _audioManager;

        [SerializeField]
        private GameObject _startingMenu;

        [SerializeField]
        private GameObject _inGameUI;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _player.Value.Freeze();
            _audioManager.PlaySoundtrack();
            _startingMenu.gameObject.SetActive(true);
            _inGameUI.gameObject.SetActive(false);
        }

        public void StartGame()
        {
            _player.Value.UnFreeze();
            _audioManager.StopSoundtrack();
            _audioManager.PlayAmbiance();
            _childrenSavedCount.Reset();
            _inGameUI.gameObject.SetActive(true);
            _startingMenu.gameObject.SetActive(false);
        }

        public void Restart()
        {
        }
    }
}

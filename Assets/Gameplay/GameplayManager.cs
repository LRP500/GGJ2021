using System.Collections;
using Tools.Audio;
using Tools.Variables;
using UnityEngine;
using UnityEngine.Serialization;

namespace GGJ2021
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("General")]

        [SerializeField]
        private CameraManager _cameraManager;

        [SerializeField]
        private AudioManager _audioManager;

        [SerializeField]
        private PlayerVariable _player;

        [SerializeField]
        private BoolVariable _gameStarted;

        [Header("UI")]

        [SerializeField]
        [FormerlySerializedAs("_startingMenu")]
        private GameObject _startingMenuUI;

        [SerializeField]
        private GameObject _inGameUI;

        [Header("Progress")]

        [SerializeField]
        private IntVariable _childrenSavedCount;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _player.Value.Freeze();
            _audioManager.PlaySoundtrack();
            _startingMenuUI.gameObject.SetActive(true);
            _inGameUI.gameObject.SetActive(false);
            _cameraManager.SwitchToStartingScreenView();
        }

        public void StartGame()
        {
            _startingMenuUI.gameObject.SetActive(false);
            _audioManager.OnGameStart();
            _childrenSavedCount.Reset();
            _cameraManager.SwitchToPlayerView();
            _gameStarted.SetValue(true);

            StartCoroutine(EnablePlayer());
        }

        /// <summary>
        /// Waits for camera blend and unfreezes player.
        /// </summary>
        private IEnumerator EnablePlayer()
        {
            yield return new WaitForSeconds(2);
            _inGameUI.gameObject.SetActive(true);
            _player.Value.UnFreeze();
        }
    }
}

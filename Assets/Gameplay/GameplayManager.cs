using System.Collections;
using NaughtyAttributes;
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

        [SerializeField]
        private BoolVariable _playerVictory;

        [SerializeField]
        private BoolVariable _playerDeath;

        [Header("UI")]

        [SerializeField]
        [FormerlySerializedAs("_startingMenu")]
        private GameObject _startingMenuUI;

        [SerializeField]
        private InGameUI _inGameUI;

        [Header("Progress")]

        [Tag]
        [SerializeField]
        private string _childrenTag;

        [SerializeField]
        private IntVariable _childrenSavedCount;

        private int _childrenCount;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _gameStarted.SetValue(false);
            _playerDeath.SetValue(false);
            _playerVictory.SetValue(false);

            _player.Value.Freeze();
            _audioManager.PlaySoundtrack();
            _inGameUI.gameObject.SetActive(false);
            _startingMenuUI.gameObject.SetActive(true);
            _cameraManager.SwitchToStartingScreenView();

            _childrenSavedCount.Reset();
            _childrenCount = GameObject.FindGameObjectsWithTag(_childrenTag).Length;
        }

        public void StartGame()
        {
            _startingMenuUI.gameObject.SetActive(false);
            _inGameUI.Initialize(_childrenCount);
            _cameraManager.SwitchToPlayerView();
            _audioManager.OnGameStart();
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

        private void Update()
        {
            if (CheckForVictory())
            {
                _player.Value.Freeze();
                _playerVictory.SetValue(true);
            }
        }

        private bool CheckForVictory()
        {
            return _childrenSavedCount.Value == _childrenCount;
        }
    }
}

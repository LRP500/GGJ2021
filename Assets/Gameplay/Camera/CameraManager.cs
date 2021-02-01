using UnityEngine;

namespace GGJ2021
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField]
        private CMVirtualCameraVariable _startingMenuCamera;

        [SerializeField]
        private CMVirtualCameraVariable _playerCamera;

        public void SwitchToStartingScreenView()
        {
            _startingMenuCamera.Value.enabled = true;
            _playerCamera.Value.enabled = false;
        }

        public void SwitchToPlayerView()
        {
            _playerCamera.Value.enabled = true;
            _startingMenuCamera.Value.enabled = false;
        }
    }
}

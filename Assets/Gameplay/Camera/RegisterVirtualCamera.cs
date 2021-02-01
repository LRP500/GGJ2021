using Cinemachine;
using UnityEngine;

namespace GGJ2021
{
    public class RegisterVirtualCamera : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        [SerializeField]
        private CMVirtualCameraVariable _virtualCameraVariable;

        private void Awake()
        {
            _virtualCameraVariable.SetValue(_virtualCamera);
        }
    }
}
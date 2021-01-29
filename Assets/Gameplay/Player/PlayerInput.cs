using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class PlayerInput : MonoBehaviour
    {
        public const KeyCode InteractKey = KeyCode.E;

        [SerializeField]
        private CameraVariable _mainCamera;

        private void Update()
        {
            if (Input.GetKeyDown(InteractKey))
            {
                _mainCamera.Value.GetComponent<Interactor>().TryInteract();
            }
        }
    }
}

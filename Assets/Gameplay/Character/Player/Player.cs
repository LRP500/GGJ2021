using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class Player : Character
    {
        [SerializeField]
        private PlayerVariable _runtimeReference;

        [SerializeField]
        private CameraVariable _mainCamera;

        [SerializeField]
        private GameObject _body;

        private void Awake()
        {
            _runtimeReference.SetValue(this);
        }

        private void Update()
        {
            if (PlayerInput.Interact)
            {
                _mainCamera.Value.GetComponent<Interactor>().TryInteract();
            }
        }

        public void Freeze()
        {
            _body.SetActive(false);
        }

        public void UnFreeze()
        {
            _body.SetActive(true);
        }
    }
}

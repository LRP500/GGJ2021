using Cinemachine;
using UnityEngine;

namespace GGJ2021
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _camera;

        [SerializeField]
        private GameObject _body;

        [SerializeField]
        private PlayerVariable _runtimeReference;

        private void Awake()
        {
            _runtimeReference.SetValue(this);
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

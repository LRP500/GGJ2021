using UnityEngine;
using UnityEngine.Serialization;

namespace GGJ2021
{
    public class Player : Character
    {
        [SerializeField]
        [FormerlySerializedAs("_playerMouseLook")]
        private PlayerMouseLook _mouseLook;

        [SerializeField]
        [FormerlySerializedAs("_playerMovement")]
        private PlayerMovement _movement;

        [SerializeField]
        private PlayerVariable _runtimeReference;

        private void Awake()
        {
            _runtimeReference.SetValue(this);
        }

        public void Freeze()
        {
            _movement.enabled = false;
            _mouseLook.enabled = false;
        }

        public void UnFreeze()
        {
            _movement.enabled = true;
            _mouseLook.enabled = true;
        }
    }
}

using UnityEngine;

namespace GGJ2021
{
    public class PlayerCrouch : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private Transform _headRig;

        [SerializeField]
        private float _crouchHeight = -1f;

        [SerializeField]
        private float _crouchSpeed = 1f;

        private void Update()
        {
            Vector3 position = _headRig.transform.localPosition;
            float targettedheight = PlayerInput.Crouch && _controller.isGrounded ? _crouchHeight : 0;
            float height = Mathf.MoveTowards(position.y, targettedheight, _crouchSpeed / 10f);
            _headRig.transform.localPosition = new Vector3(position.x, height, position.z);
        }
    }
}

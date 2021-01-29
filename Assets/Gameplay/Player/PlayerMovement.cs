using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace GGJ2021
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        [FormerlySerializedAs("_speed")]
        private float _walkSpeed = 2f;

        [SerializeField]
        private float _runSpeed = 5f;

        [SerializeField]
        private float _gravity = 9.81f;

        [SerializeField]
        private float _jumpForce = 8f;

        [SerializeField]
        private Transform _playerBody = null;

        //[SerializeField]
        //private AudioSource _audioSource = null;

        //[SerializeField]
        //private SimpleAudioEvent _footStepsSFX = null;

        private float _verticalSpeed;

        private bool _isMoving;

        private void Update()
        {
            // Get input values
            float axisX = Input.GetAxis("Horizontal");
            float axisY = Input.GetAxis("Vertical");
            bool jumpInput = Input.GetKeyDown(KeyCode.Space);

            // Calculate horizontal movement
            float speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
            Vector3 move = (_playerBody.right * axisX + _playerBody.forward * axisY) * speed;

            // Apply jump to vertical speed if grounded
            if (_controller.isGrounded)
            {
                if (jumpInput)
                {
                    _verticalSpeed = _jumpForce;
                }
            }

            // Apply vertical speed
            _verticalSpeed -= _gravity * Time.deltaTime;
            move.y = _verticalSpeed;

            // Apply movement to character controller
            _controller.Move(move * Time.deltaTime);

            // Trigger footstep audio sequence if necessary
            if (_isMoving && move.sqrMagnitude <= 0.1)
            {
                _isMoving = false;
                StopAllCoroutines();
            }
            else if (!_isMoving && move.sqrMagnitude > 0.1)
            {
                _isMoving = true;
                StartCoroutine(FootSteps());
            }
        }

        private static IEnumerator FootSteps()
        {
            const float interval = 0.6f;
            float timer = 0.5f;

            while (true)
            {
                if (timer >= interval)
                {
                    //_footStepsSFX.Play(_audioSource);
                    timer = 0;
                }

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}

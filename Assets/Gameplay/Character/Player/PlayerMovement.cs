using System.Collections;
using UnityEngine;

namespace GGJ2021
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField]
        private float _crouchSpeed = 2f;

        [SerializeField]
        private float _jumpForce = 8f;

        //[SerializeField]
        //private AudioSource _audioSource = null;

        //[SerializeField]
        //private SimpleAudioEvent _footStepsSFX = null;
        
        private bool _isMoving;

        private void Update()
        {
            // Calculate horizontal movement
            float speed = PlayerInput.Crouch ? _crouchSpeed : PlayerInput.Run ? RunSpeed : WalkSpeed;
            Vector3 horizontal = Body.right * PlayerInput.HorizontalAxis;
            Vector3 vertical = Body.forward * PlayerInput.VerticalAxis;
            Vector3 move = horizontal + vertical;

            // Apply jump to vertical speed if grounded
            if (Controller.isGrounded && !PlayerInput.Crouch)
            {
                if (PlayerInput.Jump)
                {
                    _verticalSpeed = _jumpForce;
                }
            }

            // Apply movement to character controller
            Move(move, speed);

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
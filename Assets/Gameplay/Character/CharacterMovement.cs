using UnityEngine;

namespace GGJ2021
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform _body;

        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private float _walkSpeed = 4f;

        [SerializeField]
        private float _runSpeed = 8f;

        [SerializeField]
        private float _gravity = 9.81f;

        protected float _verticalSpeed;

        public Transform Body => _body;
        public CharacterController Controller => _controller;
        
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;

        public void Move(Vector3 move, float speed)
        {
            _verticalSpeed -= _gravity * Time.deltaTime;
            Controller.Move(new Vector3(move.x, _verticalSpeed, move.z) * (speed * Time.deltaTime));
        }
    }
}

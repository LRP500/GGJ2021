using UnityEngine;

namespace GGJ2021
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform _body;

        [SerializeField]
        private float _walkSpeed = 4f;

        [SerializeField]
        private float _runSpeed = 8f;

        [SerializeField]
        private float _gravity = 9.81f;

        protected float _verticalSpeed;

        public Transform Body => _body;
        
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float Gravity => _gravity;

        public abstract void Move(Vector3 move, float speed);
    }
}

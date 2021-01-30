using UnityEngine;
using UnityEngine.AI;

namespace GGJ2021
{
    public class AIMotor : CharacterMovement
    {
        [SerializeField]
        private NavMeshAgent _agent;

        [SerializeField]
        private Animator _animator;

        public bool IsMoving { get; private set; }

        private void Update()
        {
            bool moving = _agent.velocity.magnitude <= 0.1f;

            // Update animator parameter on state changed
            if (!IsMoving && moving)
            {
                _animator.SetBool("Moving", true);
            }
            else if (!moving && IsMoving)
            {
                _animator.SetBool("Moving", false);
            }

            IsMoving = moving;
        }

        public override void Move(Vector3 move, float speed)
        {
            _agent.speed = speed;
            _agent.Move(move.normalized * Time.deltaTime);
        }

        public void SetDestination(Vector3 destination, float speed)
        {
            _agent.speed = speed;
            _agent.SetDestination(destination);
        }

        public bool HasReachedDestination()
        {
            return !_agent.hasPath && _agent.remainingDistance <= _agent.stoppingDistance;
        }
    }
}

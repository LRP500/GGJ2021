using UnityEngine;
using UnityEngine.AI;

namespace GGJ2021
{
    public class AIMotor : CharacterMovement
    {
        [SerializeField]
        private NavMeshAgent _agent;

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

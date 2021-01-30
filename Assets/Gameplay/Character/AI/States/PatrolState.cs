using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Patrol")]
    public class PatrolState : AIState
    {
        private enum PathMode
        {
            Ordered,
            Closest,
            Random
        }

        [SerializeField]
        private PathMode _mode = PathMode.Closest;

        [SerializeField]
        private AIPatrolPath _path;

        public override void EnterState(AIStateMachine character) { }
        public override void ExitState(AIStateMachine character) { }

        protected override void RunBehaviour(AIStateMachine character)
        {
            AIMotor motor = character.Motor;

            if (character.Motor.HasReachedDestination())
            {
                Transform nextWaypoint = _mode switch
                {
                    PathMode.Ordered => _path.GetNextWaypoint(),
                    PathMode.Closest => _path.GetClosest(motor.transform.position),
                    PathMode.Random => _path.GetRandom(),
                    _ => character.transform
                };

                if (nextWaypoint != null)
                {
                    motor.SetDestination(nextWaypoint.position, motor.WalkSpeed);
                }
            }
        }
    }
}

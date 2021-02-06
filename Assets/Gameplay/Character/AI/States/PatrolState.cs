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

        protected override void RunBehaviour()
        {
            AIMotor motor = Character.Motor;

            if (Character.Motor.HasReachedDestination())
            {
                Transform nextWaypoint = _mode switch
                {
                    PathMode.Ordered => _path.GetNextWaypoint(),
                    PathMode.Closest => _path.GetClosest(motor.transform.position),
                    PathMode.Random => _path.GetRandom(),
                    _ => Character.transform
                };

                if (nextWaypoint != null)
                {
                    motor.SetDestination(nextWaypoint.position, motor.WalkSpeed);
                }
            }
        }
    }
}

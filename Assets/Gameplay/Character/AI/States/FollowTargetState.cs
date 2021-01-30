using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        private TransformVariable _target;

        public override void Initialize(AIStateMachine character)
        {
        }

        public override void Execute(AIStateMachine character)
        {
            AIMotor motor = character.Motor;
            Vector3 direction = _target.Value.position - motor.transform.position;
            motor.Move(direction, motor.WalkSpeed);
        }
    }
}
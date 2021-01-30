using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        private TransformVariable _target;

        public override void Initialize(AIStateMachine character) { }

        protected override void RunBehaviour(AIStateMachine character)
        {
            AIMotor motor = character.Motor;
            Vector3 aiPos = motor.transform.position;
            Vector3 targetPos = _target.Value.position;
            Vector3 direction = targetPos - aiPos;
            character.Motor.Move(direction, motor.WalkSpeed);
        }
    }
}
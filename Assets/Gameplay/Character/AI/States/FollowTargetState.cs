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
            Vector3 aiPos = character.transform.position;
            Vector3 targetPos = _target.Value.position;
            //Vector3 direction = targetPos - aiPos;
            character.Motor.SetDestination(targetPos, character.Motor.WalkSpeed);
            //character.Motor.Move(direction, character.Motor.WalkSpeed);
        }
    }
}
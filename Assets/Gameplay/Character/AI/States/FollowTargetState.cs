using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        private TransformVariable _target;

        public override void EnterState(AIStateMachine character)
        {
            character.GetComponent<Character>().SetFollowing(true);
        }

        public override void ExitState(AIStateMachine character)
        {
            character.GetComponent<Character>().SetFollowing(false);
        }

        protected override void RunBehaviour(AIStateMachine character)
        {
            character.Motor.SetDestination(_target.Value.position, character.Motor.WalkSpeed);
        }
    }
}
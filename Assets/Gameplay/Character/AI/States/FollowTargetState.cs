using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        protected TransformVariable _target;

        protected override void OnEnterState(AIStateMachine character)
        {
            character.GetComponent<Character>().SetFollowing(true);
        }

        protected override void OnExitState(AIStateMachine character)
        {
            character.GetComponent<Character>().SetFollowing(false);
        }

        protected override void RunBehaviour(AIStateMachine character)
        {
            character.Motor.SetDestination(_target.Value.position, character.Motor.WalkSpeed);
        }
    }
}
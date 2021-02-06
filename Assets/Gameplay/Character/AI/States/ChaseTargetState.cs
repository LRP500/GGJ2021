using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Chase Target")]
    public class ChaseTargetState : FollowTargetState
    {
        protected override void RunBehaviour(AIStateMachine character)
        {
            character.Motor.SetDestination(_target.Value.position, character.Motor.WalkSpeed);
        }
    }
}
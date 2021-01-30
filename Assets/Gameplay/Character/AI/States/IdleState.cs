using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Idle")]
    public class IdleState : AIState
    {
        public override void EnterState(AIStateMachine character) { }
        public override void ExitState(AIStateMachine character) { }

        protected override void RunBehaviour(AIStateMachine character)
        {
        }
    }
}


using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Idle")]
    public class IdleState : AIState
    {
        public override void Initialize(AIStateMachine character) { }

        protected override void RunBehaviour(AIStateMachine character)
        {
        }
    }
}

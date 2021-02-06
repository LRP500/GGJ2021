using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        private TransformVariable _target;

        protected virtual float Speed => Character.Motor.WalkSpeed;

        protected override void OnEnterState()
        {
            Character.GetComponent<Character>().SetFollowing(true);
        }

        protected override void OnExitState()
        {
            Character.GetComponent<Character>().SetFollowing(false);
        }

        protected override void RunBehaviour()
        {
            Character.Motor.SetDestination(_target.Value.position, Speed);
        }
    }
}
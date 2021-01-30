using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Follow Target")]
    public class FollowTargetState : AIState
    {
        [SerializeField]
        private TransformVariable _target;

        [SerializeField]
        private float _maxDistance = 10f;

        public override void Initialize(AIStateMachine character)
        {
        }

        public override void Execute(AIStateMachine character)
        {
            Vector3 aiPos = character.Motor.transform.position;
            Vector3 targetPos = _target.Value.position;

            if (Vector3.Distance(aiPos, targetPos) <= _maxDistance)
            {
                Vector3 direction = targetPos - aiPos;
                character.Motor.Move(direction, character.Motor.WalkSpeed);
            }
        }
    }
}
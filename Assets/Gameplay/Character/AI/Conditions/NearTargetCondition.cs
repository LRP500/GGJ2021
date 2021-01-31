using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/Conditions/Near Target")]
    public class NearTargetCondition : AICondition
    {
        [SerializeField]
        private TransformVariable _target;

        [SerializeField]
        private float _maxDistance = 10f;

        public override bool Evaluate(AIStateMachine character)
        {
            if (_target.Value == null)
            {
                return false;
            }

            AIMotor motor = character.Motor;
            Vector3 characterPos = motor.transform.position;
            Vector3 targetPos = _target.Value.position;
            return Vector3.Distance(targetPos, characterPos) <= _maxDistance;
        }
    }
}
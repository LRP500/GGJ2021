using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/Conditions/Target In Sight")]
    public class TargetInSightCondition : AICondition
    {
        [SerializeField]
        private float _sightDistance = 20f;

        [SerializeField]
        private float _sphereCastRadius = 5f;

        [SerializeField]
        private TransformVariable _target;

        [SerializeField]
        private LayerMask _targetLayer;

        public override bool Evaluate(AIStateMachine character)
        {
            AIMotor motor = character.Motor;

            if (Vector3.Distance(_target.Value.position, motor.transform.position) > _sightDistance)
            {
                return false;
            }

            Transform origin = character.Motor.transform;
            Ray ray = new Ray(origin.position, origin.forward);
            return Physics.SphereCast(ray, _sphereCastRadius, _sightDistance, _targetLayer);
        }
    }
}

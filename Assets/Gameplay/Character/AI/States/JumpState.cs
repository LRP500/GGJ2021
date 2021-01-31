using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Jump")]
    public class JumpState : AIState
    {
        [SerializeField] private float _moveExtensionRatio;
        [SerializeField] private float _maxMoveExtension;
        [SerializeField] AnimationCurve _jumpCurve;

        [SerializeField]
        private TransformVariable _target;

        private Vector3 _endMovement;
        private Vector3 _startMovement;
        
        public override void EnterState(AIStateMachine character)
        {
            // todo : set jump animation ? 
            character.GetComponent<Character>().SetFollowing(true);

            _startMovement = character.Motor.transform.position;
            _endMovement = FindEndMovement(_startMovement, _target.Value.position);
            
            
        }

        public override void ExitState(AIStateMachine character)
        {
            character.GetComponent<Character>().SetFollowing(false);
        }

        protected override void RunBehaviour(AIStateMachine character)
        {
            
        }
        
        Vector3 FindEndMovement(Vector3 start, Vector3 target)
        {
            Vector2 start2D = WorldConversion.ToVector2(start);
            Vector2 target2D = WorldConversion.ToVector2(target);

            Vector2 move2D = (target2D - start2D);
            Vector2 extension2D = move2D * _moveExtensionRatio;

            if (extension2D.magnitude > _maxMoveExtension)
            {
                extension2D.Normalize();
                extension2D *= _maxMoveExtension;
            }

            Vector2 end2D = target2D + extension2D;

            return WorldConversion.ToVector3(end2D);
        }
    }
    
    public static class WorldConversion
    {
        public static Vector2 ToVector2(Vector3 v3)
        {
            return new Vector2(v3.x, v3.z);
        }

        public static Vector3 ToVector3(Vector2 v2)
        {
            return new Vector3(v2.x, 0f, v2.y);
        }
    }
}
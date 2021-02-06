using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/States/Chase Target")]
    public class ChaseTargetState : FollowTargetState
    {
        protected override float Speed => Character.Motor.RunSpeed;
    }
}
using UnityEngine;

namespace GGJ2021
{
    public abstract class AIState : ScriptableObject
    {
        public abstract void Initialize(AIStateMachine character);
        public abstract void Execute(AIStateMachine character);
    }
}

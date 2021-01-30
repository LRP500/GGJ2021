using UnityEngine;

namespace GGJ2021
{
    public abstract class AICondition : ScriptableObject
    {
        public abstract bool Evaluate(AIStateMachine character);
    }
}

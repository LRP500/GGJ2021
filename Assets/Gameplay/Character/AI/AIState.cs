using System.Collections;
using UnityEngine;

namespace GGJ2021
{
    public abstract class AIState : ScriptableObject
    {
        [SerializeField]
        private AICondition _endCondition;

        [SerializeField]
        private AIState _trueState;

        [SerializeField]
        private AIState _falseState;

        public abstract void Initialize(AIStateMachine character);

        protected abstract void RunBehaviour(AIStateMachine character);
        
        public IEnumerator Execute(AIStateMachine controller)
        {
            RunBehaviour(controller);

            yield return new WaitForEndOfFrame();

            if (_endCondition)
            {
                bool evaluation = _endCondition.Evaluate(controller);
                controller.RunState(evaluation ? _trueState : _falseState);
            }
        }
    }
}
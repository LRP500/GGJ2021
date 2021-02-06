using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2021
{
    public abstract class AIState : ScriptableObject
    {
        #region Nested Types

        [System.Serializable]
        private struct Outcome
        {
            public AICondition condition;
            public AIState trueState;
            public AIState falseState;

            public AIState Execute(AIStateMachine character)
            {
                bool evaluation = condition.Evaluate(character);

                return evaluation switch
                {
                    true when trueState => trueState,
                    false when falseState => falseState,
                    _ => null
                };
            }
        }

        #endregion Nested Types

        [SerializeField]
        private List<Outcome> _outcomes;

        public void EnterState(AIStateMachine character)
        {
            OnEnterState(character);
        }

        public void ExitState(AIStateMachine character)
        {
            OnExitState(character);
        }

        protected virtual void OnEnterState(AIStateMachine character) { }
        protected virtual void OnExitState(AIStateMachine character) { }

        protected abstract void RunBehaviour(AIStateMachine character);
        
        public IEnumerator Execute(AIStateMachine character)
        {
            RunBehaviour(character);

            yield return new WaitForEndOfFrame();

            for (int i = 0; i < _outcomes.Count; i++)
            {
                AIState outcome = _outcomes[i].Execute(character);
                if (outcome != null)
                {
                    character.RunState(outcome);
                }
            }

            character.RunState(character.CurrentState);
        }
    }
}
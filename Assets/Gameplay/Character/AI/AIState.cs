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

        protected AIStateMachine Character { get; private set; }

        public void EnterState(AIStateMachine character)
        {
            Character = character;
            OnEnterState();
        }

        public void ExitState(AIStateMachine character)
        {
            OnExitState();
        }

        protected virtual void OnEnterState() { }
        protected virtual void OnExitState() { }

        protected abstract void RunBehaviour();
        
        public IEnumerator Execute()
        {
            RunBehaviour();

            yield return new WaitForEndOfFrame();

            for (int i = 0; i < _outcomes.Count; i++)
            {
                AIState outcome = _outcomes[i].Execute(Character);
                if (outcome != null)
                {
                    Character.RunState(outcome);
                }
            }

            Character.RunState(Character.CurrentState);
        }
    }
}
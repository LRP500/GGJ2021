using NaughtyAttributes;
using UnityEngine;

namespace GGJ2021
{
    public class AIStateMachine : MonoBehaviour
    {
        [SerializeField]
        private AIMotor _motor;

        [SerializeField]
        private AISensor _sensor;

        public AIMotor Motor => _motor;
        public AISensor Sensor => _sensor;

        /// <summary>
        /// Starting state.
        /// </summary>
        [Space]
        [SerializeField]
        private AIState _initialState;

        /// <summary>
        /// Currently running state.
        /// </summary>
        [ReadOnly]
        [SerializeField]
        private AIState _currentState;

        /// <summary>
        /// Previously visited state.
        /// </summary>
        [ReadOnly]
        [SerializeField]
        private AIState _previousState = null;

        [SerializeField]
        private bool _autoStart = true;

        private void Start()
        {
            if (_autoStart)
            {
                Run();
            }
        }

        public void Run()
        {
            RunState(_initialState);
        }

        public virtual void RunState(AIState state)
        {
            _previousState = _currentState;
            _currentState = state;
            StartCoroutine(state.Execute(this));
        }
    }
}

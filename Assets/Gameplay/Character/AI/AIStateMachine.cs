using UnityEngine;

namespace GGJ2021
{
    public class AIStateMachine : MonoBehaviour
    {
        [SerializeField]
        private AIMotor _motor;

        [SerializeField]
        private AISensor _sensor;

        [SerializeField]
        private AIState _initialState;

        public AIMotor Motor => _motor;
        public AISensor Sensor => _sensor;

        private AIState _currentState;

        private void Start()
        {
            _initialState.Initialize(this);
        }

        private void Update()
        {
            _initialState.Execute(this);
        }
    }
}

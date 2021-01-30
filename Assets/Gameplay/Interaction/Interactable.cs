using UnityEngine;

namespace GGJ2021
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private string _label = string.Empty;
        public string Label => _label;

        [SerializeField]
        private float _range = 1f;
        public float Range => _range;

        [SerializeField]
        private bool _canBeInteractedWith = true;

        [SerializeField]
        private Action _action = null;

        public void Interact()
        {
            if (_canBeInteractedWith)
            {
                _action.Execute();
            }
        }
    }
}
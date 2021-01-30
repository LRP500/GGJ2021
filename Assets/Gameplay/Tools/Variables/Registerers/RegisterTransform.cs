using UnityEngine;

namespace Tools.Variables
{
    public class RegisterTransform : MonoBehaviour
    {
        [SerializeField]
        private TransformVariable _variable;

        private void Awake()
        {
            _variable.SetValue(transform);
        }
    }
}

using Tools;
using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class HouseEntranceCollider : MonoBehaviour
    {
        [SerializeField]
        [TagSelector(UseDefaultTagFieldDrawer = true)]
        private string _childrenTag;

        [SerializeField]
        private IntVariable _childrenSavedCount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_childrenTag))
            {
                Destroy(other.transform.parent.gameObject);
                _childrenSavedCount.Increment();
            }
        }
    }
}

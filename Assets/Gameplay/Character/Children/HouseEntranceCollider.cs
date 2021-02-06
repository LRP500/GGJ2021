using Tools;
using Tools.Audio;
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

        [SerializeField]
        private AudioEventPlayer _chidrenCheer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_childrenTag))
            {
                _chidrenCheer.Play();
                _childrenSavedCount.Increment();
                other.GetComponentInParent<Child>().Save();
            }
        }
    }
}

using UnityEngine;

namespace GGJ2021
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public Animator Animator => _animator;

        public bool Following { get; private set; }

        public void SetFollowing(bool following)
        {
            Following = following;
            Animator.SetBool("Following", Following);
        }
    }
}
using System;
using UnityEngine;

namespace GGJ2021
{
    public class GrandmaDeathCollider : MonoBehaviour
    {
        [SerializeField] private DeathUI _deathUI;
        [SerializeField] private Player _player;
        
        private void OnTriggerEnter(Collider other)
        {
            _deathUI.OnDeath();
            _player.Freeze();
        }
    }
}
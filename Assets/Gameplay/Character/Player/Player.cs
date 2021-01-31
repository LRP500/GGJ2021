﻿using UnityEngine;

namespace GGJ2021
{
    public class Player : Character
    {
        [SerializeField]
        private PlayerMouseLook _playerMouseLook;
        
        [SerializeField]
        private PlayerVariable _runtimeReference;

        [SerializeField]
        private GameObject _body;

        private void Awake()
        {
            _runtimeReference.SetValue(this);
        }

        public void Freeze()
        {
            _body.SetActive(false);
            _playerMouseLook.enabled = false;
        }

        public void UnFreeze()
        {
            _body.SetActive(true);
            _playerMouseLook.enabled = true;
        }
    }
}

using UnityEngine;

namespace GGJ2021
{
    public class StartingMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _inGameUI;
        [SerializeField] private PlayerVariable _player;

        public void StartTheGame()
        {
            _inGameUI.SetActive(true);
            gameObject.SetActive(false);
            
            _player.Value.UnFreeze();
        }
    }
}
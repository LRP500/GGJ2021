using Tools.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GGJ2021
{
    public class VictoryUI : MonoBehaviour
    {
        [SerializeField]
        private BoolVariable _playerVictory;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private Button _button;

        private void Awake()
        {
            _playerVictory.Subscribe(Refresh);
            _button.onClick.AddListener(RestartGame);
        }

        private void OnDestroy()
        {
            _playerVictory.Unsubscribe(Refresh);
        }

        private void SetVisible(bool visible)
        {
            _canvasGroup.alpha = visible ? 1 : 0;
            _canvasGroup.interactable = visible;
            _canvasGroup.blocksRaycasts = visible;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Refresh()
        {
            SetVisible(_playerVictory);
        }
    }
}

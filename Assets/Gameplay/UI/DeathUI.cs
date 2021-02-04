using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ2021
{
    public class DeathUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private CanvasGroup _canvasGroupBackground;
        [SerializeField] private CanvasGroup _canvasGroupText;
        [SerializeField] private CanvasGroup _canvasGroupButton;
        [SerializeField] private float _animDuration = 1f;
        [SerializeField] private float _animDelayText = 1f;
        [SerializeField] private float _animDelayReplay = 1f;

        private float _time;
        private bool _dead;

        private void Awake()
        {
            _canvasGroupBackground.alpha = 0;
            _canvasGroupText.alpha = 0;
            _canvasGroupButton.alpha = 0;
        }

        public void OnDeath()
        {
            _gameObject.SetActive(true);
            _dead = true;
        }

        private void Update()
        {
            if (_dead)
            {
                _time += Time.deltaTime;
                SetAlpha(_time * _animDuration, _canvasGroupBackground);

                if (_time > _animDelayText)
                {
                    float timeText = _time - _animDelayText;
                    SetAlpha(timeText * _animDuration, _canvasGroupText);
                }

                if (_time > _animDelayText + _animDelayReplay)
                {
                    float timeText = _time - _animDelayText - _animDelayReplay;
                    SetAlpha(timeText * _animDuration, _canvasGroupButton);
                }
            }
        }

        private void SetAlpha(float alpha, CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = alpha;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
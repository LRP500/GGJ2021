using TMPro;
using UnityEngine;

namespace GGJ2021
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        [SerializeField]
        private TextMeshProUGUI _key = null;

        [SerializeField]
        private TextMeshProUGUI _label = null;

        public void SetInteractable(Interactable interactable)
        {
            if (interactable == null)
            {
                Hide();
                return;
            }

            _key.text = PlayerInput.InteractKey.ToString();
            _label.text = interactable.Label;
            Show();
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
        }
    }
}

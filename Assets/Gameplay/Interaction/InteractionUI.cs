using TMPro;
using UnityEngine;

namespace GGJ2021
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private TextMeshProUGUI _key;

        [SerializeField]
        private TextMeshProUGUI _label;

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

        private void Hide()
        {
            _canvasGroup.alpha = 0;
        }

        private void Show()
        {
            _canvasGroup.alpha = 1;
        }
    }
}

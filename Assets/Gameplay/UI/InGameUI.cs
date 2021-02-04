using TMPro;
using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _childrenScoreDisplay;

        [SerializeField]
        private IntVariable _childrenSaved;

        private int _childrenCount;

        private void OnDestroy()
        {
            _childrenSaved.Unsubscribe(Refresh);
        }

        public void Initialize(int childrenCount)
        {
            _childrenCount = childrenCount;
            _childrenSaved.Subscribe(Refresh);
            Refresh();
        }

        private void Refresh()
        {
            _childrenScoreDisplay.text = $"{_childrenSaved}/{_childrenCount} Children Saved";
        }
    }
}
using TMPro;
using Tools.Variables;
using UnityEngine;

namespace GGJ2021
{
    public class DisplayChildrenSavedCount : MonoBehaviour
    {
        [SerializeField]
        private IntVariable _childrenSaveCount;

        [SerializeField]
        private TextMeshProUGUI _display;

        private void Awake()
        {
            _childrenSaveCount.Subscribe(Refresh);
        }

        private void Start()
        {
            Refresh();
        }

        private void OnDestroy()
        {
            _childrenSaveCount.Unsubscribe(Refresh);
        }

        private void Refresh()
        {
            _display.text = $"{_childrenSaveCount.Value} / 10 Children Saved";
        }
    }
}

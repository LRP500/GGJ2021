using UnityEditor;
using UnityEngine;

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Scene Reference")]
    public class SceneReference : ScriptableObject
    {
#if UNITY_EDITOR
        public SceneAsset asset;
#endif
        public new string name;

        public string path;

#if UNITY_EDITOR
        private void Refresh()
        {
            name = asset.name;
            path = AssetDatabase.GetAssetPath(asset);
        }
#endif

        private void OnValidate()
        {
            Refresh();
        }
    }
}

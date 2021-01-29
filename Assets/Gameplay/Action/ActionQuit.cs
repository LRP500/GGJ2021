using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "Actions/Quit")]
    public class ActionQuit : Action
    {
        public override void Execute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }
    }
}

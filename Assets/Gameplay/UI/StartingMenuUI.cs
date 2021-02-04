using UnityEngine;

namespace GGJ2021
{
    public class StartingMenuUI : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
            }
        }
    }
}
using Tools.Variables;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _childrenSavedCount;

    private void Awake()
    {
        StartGame();
    }

    private void StartGame()
    {
        _childrenSavedCount.Reset();
    }
}

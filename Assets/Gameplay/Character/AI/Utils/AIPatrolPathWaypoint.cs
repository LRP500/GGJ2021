using UnityEngine;

namespace GGJ2021
{
    public class AIPatrolPathWaypoint : MonoBehaviour
    {
        [SerializeField]
        private AIPatrolPath _path;

        private void Awake()
        {
            _path.AddWaypoint(transform);
        }

        private void OnDestroy()
        {
            _path.RemoveWaypoint(transform);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 1.5f);
        }
    }
}

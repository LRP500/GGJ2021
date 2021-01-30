using System.Collections.Generic;
using UnityEngine;

namespace GGJ2021
{
    [CreateAssetMenu(menuName = "AI/Utils/Patrol Path")]
    public class AIPatrolPath : ScriptableObject
    {
        [SerializeField]
        private List<Transform> _waypoints;

        private int _lastWaypointIndex = -1;

        public void AddWaypoint(Transform waypoint)
        {
            _waypoints.Add(waypoint);
        }

        public void RemoveWaypoint(Transform waypoint)
        {
            _waypoints.Remove(waypoint);
        }

        private Transform GetWaypoint(int index)
        {
            _lastWaypointIndex = index;
            return _waypoints[index];
        }

        public Transform GetNextWaypoint()
        {
            _lastWaypointIndex++;

            if (_lastWaypointIndex >= _waypoints.Count)
            {
                _lastWaypointIndex = 0;
            }

            return _waypoints[_lastWaypointIndex];
        }

        public Transform GetRandom()
        {
            return GetWaypoint(Random.Range(0, _waypoints.Count));
        }

        public Transform GetClosest(Vector3 position, bool ignoreLastWaypoint = true)
        {
            float closestWaypointDistance = float.MaxValue;
            int closestWaypointIndex = -1;

            for (int i = 0; i < _waypoints.Count; i++)
            {
                if (ignoreLastWaypoint && i == _lastWaypointIndex) continue;

                float distance = Vector3.Distance(position, _waypoints[i].position);

                if (distance <= closestWaypointDistance)
                {
                    closestWaypointDistance = distance;
                    closestWaypointIndex = i;
                }
            }

            return GetWaypoint(closestWaypointIndex);
        }
    }
}

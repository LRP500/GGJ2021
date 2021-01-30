using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GGJ2021
{
    public class ChildrenSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _areaRadius = 10f;

        [SerializeField]
        private int _spawnCount;

        [SerializeField]
        private Child _childPrefab;

        [SerializeField]
        private LayerMask _groundLayer;

        private List<Child> _children;

        private void Start()
        {
            SpawnChildren(_spawnCount);
        }

        private void SpawnChildren(int count)
        {
            _children = new List<Child>(_spawnCount);

            for (int i = 0; i < count; i++)
            {
                Vector3 position = transform.position + (Random.insideUnitSphere * _areaRadius);
                position.y = SampleTerrainHeight(position);
                SpawnSingleChild(position);
            }
        }

        private Child SpawnSingleChild(Vector3 position)
        {
            Child instance = Instantiate(_childPrefab);
            instance.transform.position = position;
            _children.Add(instance);
            return instance;
        }

        private float SampleTerrainHeight(Vector3 position)
        {
            var ray = new Ray(new Vector3(0, 100, 0), Vector3.down);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 500, _groundLayer))
            {
                return hit.point.y;
            }

            return 0;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _areaRadius);
        }
    }
}

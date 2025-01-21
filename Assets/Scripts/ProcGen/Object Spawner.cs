using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _obstacleParent;
    [SerializeField] private float _delaySeconds = 1f;
    [SerializeField] private float _spawnWidth = 4f;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true) {
            GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
            Vector3 spawnPos = new(transform.position.x + Random.Range(-_spawnWidth, _spawnWidth), transform.position.y, transform.position.z);

            yield return new WaitForSeconds(_delaySeconds);
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, _obstacleParent);
        }
    }
}

using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _obstacleParent;
    [SerializeField] private float _delaySeconds = 1f;
    [SerializeField] private float _spawnWidth = 4f;
    [SerializeField] private int _numToSpawn = 2;
    [SerializeField] private bool _enableRandomNoSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int numToSpawn = 1;
            if (_enableRandomNoSpawn)
            {
                numToSpawn = Random.Range(0, _numToSpawn + 1);
            }

            for (int i = 0; i < numToSpawn; i++)
            {
                GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
                Vector3 spawnPos = new(transform.position.x + Random.Range(-_spawnWidth, _spawnWidth), transform.position.y, transform.position.z);
                Instantiate(obstaclePrefab, spawnPos, Random.rotation, _obstacleParent);
            }

            yield return new WaitForSeconds(_delaySeconds);
        }
    }
}

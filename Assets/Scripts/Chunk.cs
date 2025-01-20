using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _fencePrefab;
    [SerializeField] private float[] _lanes = { 2.5f, 0f, -2.5f };

    private void Start()
    {
        SpawnFence();
    }

    private void SpawnFence()
    {
        float randomLane = _lanes[Random.Range(0, _lanes.Length)];
        Vector3 spawnPos = new(randomLane, transform.position.y, transform.position.z);
        Instantiate(_fencePrefab, spawnPos, Quaternion.identity, this.transform);
    }
}

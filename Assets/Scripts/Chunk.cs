using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _fencePrefab;
    [SerializeField]

    private void Start()
    {
        SpawnFence();
    }

    private void SpawnFence()
    {
        Vector3 spawnPos = new();

    }
}

using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject _fencePrefab;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private float[] _lanes = { -2f, 1.35f, 4.5f };
    [SerializeField] private float[] _appleLanes = { -2.5f, 0f, 2.5f };

    private List<int> availLanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        SpawnFence();
        SpawnApple();
    }

    private void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0, _lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availLanes.Count == 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPos = new(_lanes[selectedLane], transform.position.y, transform.position.z + 5f);
            Instantiate(_fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }

    private void SpawnApple()
    {
        int selectedLane = SelectLane();

        Vector3 spawnPos = new(_appleLanes[selectedLane], transform.position.y, transform.position.z + 5f);
        Instantiate(_applePrefab, spawnPos, Quaternion.identity, this.transform);
    }

    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availLanes.Count);
        int selectedLane = availLanes[randomLaneIndex];
        availLanes.RemoveAt(randomLaneIndex);

        return selectedLane;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _fencePrefab;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _coinPrefab;

    [Header("Lanes")]
    [SerializeField] private float[] _lanes = { -2f, 1.35f, 4.5f };
    [SerializeField] private float[] _pickupLanes = { -2.5f, 0f, 2.5f };

    [Header("Values")]
    [SerializeField] private float _appleSpawnChance = 0.335f;
    [SerializeField] private float _coinSpawnChance = 0.5f;
    [SerializeField] private int _maxCoinsToSpawn = 5;
    [SerializeField] private float _coinSeperation = 5f;

    private List<int> availLanes = new List<int> { 0, 1, 2 };
    private LevelGenerator _levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        _levelGenerator = levelGenerator;
    }

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnFences()
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
        if (Random.value > _appleSpawnChance || availLanes.Count == 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPos = new(_pickupLanes[selectedLane], transform.position.y, transform.position.z + 5f);
        Apple newApple = Instantiate(_applePrefab, spawnPos, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(_levelGenerator);
    }

    private void SpawnCoins()
    {
        if (Random.value > _coinSpawnChance || availLanes.Count == 0) return;

        int selectedLane = SelectLane();

        int coinsToSpawn = Random.Range(1, _maxCoinsToSpawn);
        for (int i = 0; i <= coinsToSpawn; i++)
        {
            Vector3 spawnPos = new(_pickupLanes[selectedLane], transform.position.y, transform.position.z + _coinSeperation + -i);
            Instantiate(_coinPrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }

    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availLanes.Count);
        int selectedLane = availLanes[randomLaneIndex];
        availLanes.RemoveAt(randomLaneIndex);

        return selectedLane;
    }
}

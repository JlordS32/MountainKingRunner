using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _chunkPrefabs;
    [SerializeField] private GameObject _checkpointChunkPrefab;
    [SerializeField] private Transform _chunkParent;
    [SerializeField] private CameraController _cameraController;

    [Header("Params")]
    [Tooltip("Starting chunk amount.")]
    [SerializeField] private int _startingChunkAmount = 12;
    [SerializeField] private int _checkpoint = 10;

    [Tooltip("Default size of the chunk is 10.")]
    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _minMoveSpeed = 2f;

    // Variables
    private List<GameObject> _chunks;
    private float _startingSpeed;
    private float _startingGravity;
    private int _chunkCounter = 0;

    private void Start()
    {
        _chunks = new List<GameObject>();
        InitialSpawnChunks();
        _startingSpeed = _moveSpeed;
        _startingGravity = Physics.gravity.z;
    }

    private void Update()
    {
        MoveChunks();
    }

    private void InitialSpawnChunks()
    {
        for (int i = 0; i < _startingChunkAmount; i++)
        {
            float zOffset = transform.position.z + _chunkLength * i;
            SpawnChunk(zOffset);
        }
    }

    private void MoveChunks()
    {
        for (int i = 0; i < _chunks.Count; i++)
        {
            GameObject chunk = _chunks[i];
            _chunks[i].transform.Translate(_moveSpeed * Time.deltaTime * -transform.forward);

            if (chunk.transform.position.z <= Camera.main.transform.position.z - _chunkLength)
            {
                _chunks.Remove(chunk);
                Destroy(chunk);

                // Last pos of the last chunk + offset by the chunk length to get new position.
                float zOffset = _chunks[_chunks.Count - 1].transform.position.z + _chunkLength;
                SpawnChunk(zOffset);
            }
        }
    }

    private void SpawnChunk(float zOffset)
    {
        Vector3 chunkPos = new(transform.position.x, transform.position.y, zOffset);
        GameObject chunkToSpawn;

        _chunkCounter++;
        if (_chunkCounter % _checkpoint == 0)
        {
            chunkToSpawn = _checkpointChunkPrefab;
        }
        else
        {
            chunkToSpawn = _chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)];
        }

        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkPos, Quaternion.identity, _chunkParent);
        _chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this);
    }

    public IEnumerator ChangeSpeed(int delaySeconds, float speed)
    {
        _moveSpeed += speed;
        if (_moveSpeed < _minMoveSpeed) _moveSpeed = _minMoveSpeed;
        _cameraController.ChangeCamFOV(speed);

        // Update
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speed);
        yield return new WaitForSeconds(delaySeconds);

        // Reset
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, _startingGravity);
        _moveSpeed = _startingSpeed;
    }
}

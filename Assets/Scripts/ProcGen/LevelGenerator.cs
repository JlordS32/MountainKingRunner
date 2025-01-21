using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _startingChunkAmount = 12;
    [SerializeField] private Transform _chunkParent;
    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _minMoveSpeed = 2f;
    [SerializeField] private CameraController _cameraController;

    private List<GameObject> _chunks;
    private float _startingSpeed;
    private float _startingGravity;

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
        GameObject newChunk = Instantiate(_chunkPrefab, chunkPos, Quaternion.identity, _chunkParent);

        _chunks.Add(newChunk);
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

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    
    [SerializeField] float _timeValue = 7f;

    GameManager _gameManager;

    private void Start() {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            _gameManager.IncreaseTime(_timeValue);
        }
    }
}

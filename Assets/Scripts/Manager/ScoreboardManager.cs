using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    // Singleton instance
    public static ScoreboardManager Instance { get; private set; }

    [SerializeField] private TMP_Text _scoreboardText;

    private int _score = 0;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();

        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keeps this instance persistent across scenes
    }

    public void IncreaseScore(int amount)
    {
        if (_gameManager.GameOver) return;

        _score += amount;
        _scoreboardText.text = $"Score: {_score}";
    }
}

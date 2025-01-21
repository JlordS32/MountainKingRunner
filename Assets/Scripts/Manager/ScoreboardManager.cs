using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    // Singleton instance
    public static ScoreboardManager Instance { get; private set; }

    [SerializeField] private TMP_Text _scoreboardText;

    private int _score = 0;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: Keeps this instance persistent across scenes
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreboardText.text = $"Score: {_score}";
    }
}

using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreboardText;
    [SerializeField] private GameManager _gameManager;

    private int _score = 0;

    public void IncreaseScore(int amount)
    {
        if (_gameManager.GameOver) return;

        _score += amount;
        _scoreboardText.text = $"Score: {_score}";
    }
}

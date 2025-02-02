using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController _player;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private GameObject _tipText;

    [Header("Variables")]
    [SerializeField] private float _startTime = 5f;
    [Tooltip("Time scale when game over")]
    [Range(0, 1)]
    [SerializeField] private float _timeScale = 0.1f;

    private float _timeLeft;
    private bool _gameOver = false;

    public bool GameOver => _gameOver;

    private void Start()
    {
        _timeLeft = _startTime;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }


        if (_gameOver) return;
        _timeLeft -= Time.deltaTime;
        _timeText.text = $"Time: {_timeLeft.ToString("F1")}s";

        if (_timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        _gameOver = true;
        _player.enabled = false;
        _gameOverText.SetActive(true);
        _tipText.SetActive(true);
        Time.timeScale = _timeScale;
    }

    public void IncreaseTime(float amount)
    {
        _timeLeft += amount;
    }
}

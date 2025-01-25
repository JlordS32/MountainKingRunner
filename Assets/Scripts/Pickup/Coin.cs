public class Coin : Pickup
{
    private ScoreboardManager _scoreboardManager;

    private void Start() {
        _scoreboardManager = FindFirstObjectByType<ScoreboardManager>();
    }

    protected override void OnPickup()
    {
        _scoreboardManager.IncreaseScore(100);
    }
}

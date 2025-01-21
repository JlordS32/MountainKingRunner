using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        ScoreboardManager.Instance.IncreaseScore(10);
    }
}

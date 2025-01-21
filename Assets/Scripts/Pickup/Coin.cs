using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        Debug.Log("Added 100 points");
    }
}

using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            Debug.Log("Picked up");
        }
    }
}

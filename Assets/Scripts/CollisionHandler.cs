using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
    }
}

using UnityEngine;

abstract public class Pickup : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private AudioClip _audioClip;

    private const string PLAYER_TAG = "Player";

    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            if (_audioClip != null) {
                SoundManager.Instance.PlaySound(_audioClip);
            }
            
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();
}

using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _shakeModifier = 10f;
    [SerializeField] private float _cooldown = 1f;

    private CinemachineImpulseSource _cinemachineImpulseSource;
    private AudioSource _audioSource;
    private float _timer = 0f;

    private void Awake()
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        _timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_timer < _cooldown) return;

        FireImpulse();
        FX(other);
        _timer = 0f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance * _shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        _cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    private void FX(Collision other) {
        ContactPoint contactPoint = other.contacts[0];
        _particleSystem.transform.position = contactPoint.point;
        _particleSystem.Play();
        _audioSource.Play();
    }
}

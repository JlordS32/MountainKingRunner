using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _shakeModifier = 10f;

    CinemachineImpulseSource _cinemachineImpulseSource;

    private void Awake()
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        FireImpulse();
        FX(other);
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
    }
}

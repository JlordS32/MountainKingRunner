using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem _speedUpParticle;
    [SerializeField] private float _zoomDuration = 1f;
    [SerializeField] private float _minFOV = 20f;
    [SerializeField] private float _maxFOV = 120f;
    [SerializeField] private float _zoomMultipler = 5f;

    // Variables
    private CinemachineCamera _cinemachineCamera;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCamFOV(float speed)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speed));

        if (speed > 0)
        {
            _speedUpParticle.Play();
        }
    }

    private IEnumerator ChangeFOVRoutine(float speed)
    {
        float startFOV = _cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speed * _zoomMultipler, _minFOV, _maxFOV);

        float timer = 0f;
        while (timer < _zoomDuration)
        {
            float t = timer / _zoomDuration;
            timer += Time.deltaTime;

            _cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        // Guard clause
        _cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}

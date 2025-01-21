using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float _slowDownSpeed = 5f;
    [SerializeField] private int _hitDelay = 2;
    [SerializeField] private float IFrames = 1f;

    private const string OBSTACLE_TAG = "Obstacle";
    private const string HIT_ANIMATION = "Hit";
    
    // Variables
    private LevelGenerator _levelGenerator;
    private float _timer;

    private void Start()
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    private void Update() {
        _timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OBSTACLE_TAG) && _timer >= IFrames)
        {
            _anim.SetTrigger(HIT_ANIMATION);
            StartCoroutine(_levelGenerator.SlowDown(_hitDelay, _slowDownSpeed));
            
            // Reset invincibility cooldown
            _timer = 0f;
        }
    }
}

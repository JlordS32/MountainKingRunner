using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private const string OBSTACLE_TAG = "Obstacle";
    private const string HIT_ANIMATION = "Hit";
    private LevelGenerator _levelGenerator;

    private void Start()
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OBSTACLE_TAG))
        {
            _anim.SetTrigger(HIT_ANIMATION);
        }
    }
}

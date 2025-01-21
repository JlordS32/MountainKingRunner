using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float _speedMultipler = 1.1f;
    [SerializeField] private int _duration = 1;

    LevelGenerator _levelGenerator;

    private void Start() {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        // BUG: Player won't go back to normal speed after set duration.
        StartCoroutine(_levelGenerator.Boost(_duration, _speedMultipler));
    }
}

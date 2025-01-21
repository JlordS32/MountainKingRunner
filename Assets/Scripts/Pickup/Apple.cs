using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private int _duration = 1;

    LevelGenerator _levelGenerator;

    private void Start() {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        // BUG: Player won't go back to normal speed after set duration.
        StartCoroutine(_levelGenerator.ChangeSpeed(_duration, _speed));
    }
}

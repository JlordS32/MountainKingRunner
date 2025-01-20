using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xClamp = 3f;
    [SerializeField] private float _yClamp = 3f;

    private Vector2 _movement;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        Vector3 currentPos = _rb.position;
        Vector3 direction = new(_movement.x, 0f, _movement.y);
        Vector3 newPos = currentPos + _speed * Time.fixedDeltaTime * direction;

        newPos.x = Mathf.Clamp(newPos.x, -_xClamp, _xClamp);
        newPos.y = Mathf.Clamp(newPos.y, -_yClamp, _yClamp);

        _rb.MovePosition(newPos);
    }
}

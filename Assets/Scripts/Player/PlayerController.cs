using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xClamp = 3f;
    [SerializeField] private float _zClamp = 3f;

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
        newPos.z = Mathf.Clamp(newPos.z, 0, _zClamp);

        _rb.MovePosition(newPos);
    }
}

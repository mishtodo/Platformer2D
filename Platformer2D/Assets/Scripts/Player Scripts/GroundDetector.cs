using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _overlapRadius = 0.45f;
    [SerializeField] private Vector2 _offset = new(0, -0.05f);

    private Collider2D _collider;
    private Vector2 _center;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        _center = new(transform.position.x, transform.position.y);
        _collider = Physics2D.OverlapCircle(_center + _offset, _overlapRadius);

        if (_collider != null)
            IsGrounded = true;
        else
            IsGrounded = false;
    }
}
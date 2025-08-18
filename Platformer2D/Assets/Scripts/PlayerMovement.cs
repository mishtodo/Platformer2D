using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);
        }

        _direction.x = Input.GetAxisRaw("Horizontal");
        _rigidbody.position += _direction * _speed * Time.deltaTime;
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private float _jumpForce = 10.0f;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Jumping += Jump;
    }

    private void OnDisable()
    {
        _inputReader.Jumping -= Jump;
    }

    private void Jump()
    {
        if (_raycaster.IsGrounded == true)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
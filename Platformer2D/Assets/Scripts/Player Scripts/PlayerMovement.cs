using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader), typeof(Rotator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.75f;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 _direction;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rotator = GetComponent<Rotator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Moving += FixedUpdate;
    }

    private void OnDisable()
    {
        _inputReader.Moving -= FixedUpdate;
    }

    private void Update()
    {
        if (_direction.x < 0)
            _rotator.RotateLeft();
        else if (_direction.x > 0)
            _rotator.RotateRight();

        _playerAnimations.SetSpeed(Mathf.Abs(_direction.x));
    }

    private void FixedUpdate()
    {
        _direction.x = _inputReader.DirectionX;
        _rigidbody.position += _direction * _speed * Time.fixedDeltaTime;
    }
}
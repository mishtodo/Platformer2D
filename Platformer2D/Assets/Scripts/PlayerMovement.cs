using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private Vector2 _direction;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float rayDistance = 0.75f;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);

        if (hitInfo)
            _isGrounded = true;
        else
            _isGrounded = false;


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
            _animator.Play("Jump");
        }



        _direction.x = Input.GetAxisRaw("Horizontal");
        _rigidbody.position += _direction * _speed * Time.deltaTime;



        if (_isGrounded == false)
            _animator.Play("Jump");


        if (_direction.x == 0 && _isGrounded == true)
            _animator.Play("Idle");


        if (_direction.x != 0 && _isGrounded == true)
            _animator.Play("Run");


        if (_direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private PlayerMovement _playerMovement;

    private bool _isGrounded;
    private float _directionX;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    { 
        _raycaster.Grounded += SetGrounded;
        _playerMovement.ChangingDirection += SetDirection;
    }

    private void OnDisable()
    {
        _raycaster.Grounded -= SetGrounded;
        _playerMovement.ChangingDirection -= SetDirection;
    }

    private void Update()
    {
        if (_isGrounded == false)
            _animator.Play("Jump");

        if (_directionX == 0 && _isGrounded == true)
            _animator.Play("Idle");

        if (_directionX != 0 && _isGrounded == true)
            _animator.Play("Run");

        if (_directionX < 0)
            _spriteRenderer.flipX = true;
        else if (_directionX > 0)
            _spriteRenderer.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
            Destroy(collision.gameObject);
    }

    private void SetDirection(float directionX)
    {
        _directionX = directionX;
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}
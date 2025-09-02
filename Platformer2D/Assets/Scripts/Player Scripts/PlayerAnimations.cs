using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Raycaster), typeof(InputReader))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private InputReader _inputReader;

    private string _animationJump = "Jump";
    private string _animationIdle = "Idle";
    private string _animationRun = "Run";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _raycaster = GetComponent<Raycaster>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_raycaster.IsGrounded == false)
            _animator.Play(_animationJump);

        if (_inputReader.DirectionX == 0 && _raycaster.IsGrounded == true)
            _animator.Play(_animationIdle);

        if (_inputReader.DirectionX != 0 && _raycaster.IsGrounded == true)
            _animator.Play(_animationRun);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent<Coin>(out Coin coin))
    //        Destroy(collision.gameObject);
    //}
}
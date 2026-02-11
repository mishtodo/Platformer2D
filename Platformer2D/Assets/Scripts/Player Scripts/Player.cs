using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private Animations _animations;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Mover _mover;

    private void Awake()
    {
        _animations = GetComponent<Animations>();
        _shooter = GetComponent<Shooter>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        _animations.SetGrounded(_groundDetector.IsGrounded);
        _animations.SetSpeed(Mathf.Abs(_inputReader.DirectionX));
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetIsShooting())
            _shooter.Shoot();

        if (_inputReader.DirectionX != 0)
        {
            _rotator.RotateTowardsDirection(_inputReader.DirectionX);
            _mover.Move(_inputReader.DirectionX);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGrounded)
            _mover.Jump();
    }
}
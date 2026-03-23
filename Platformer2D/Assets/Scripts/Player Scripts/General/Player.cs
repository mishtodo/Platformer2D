using UnityEngine;

[RequireComponent(typeof(Animations), typeof(Shooter), typeof(GroundDetector))]
[RequireComponent(typeof(InputReader), typeof(Rotator), typeof(Mover))]
[RequireComponent(typeof(AbilityHandler))]
public class Player : MonoBehaviour 
{
    [SerializeField] private Animations _animations;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Mover _mover;
    [SerializeField] private AbilityHandler _ability;

    private void Awake()
    {
        _animations = GetComponent<Animations>();
        _shooter = GetComponent<Shooter>();
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
        _ability = GetComponent<AbilityHandler>();
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

        if (_inputReader.GetIsLifeStealing() && _ability.IsRunning == false)
            _ability.StartAbility();
    }
}
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animations _animations;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Mover _mover;
    [SerializeField] private Follower _follower;
    [SerializeField] private Patroler _patroler;
    [SerializeField] private Vision _vision;
    [SerializeField] private EnemyDamager _damager;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animations = GetComponent<Animations>();
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
        _follower = GetComponent<Follower>();
        _patroler = GetComponent<Patroler>();
        _vision = GetComponent<Vision>();
        _damager = GetComponent<EnemyDamager>();
    }

    private void Update()
    {
        _animations.SetSpeed(Mathf.Abs(_rb.velocityX));
    }

    private void FixedUpdate()
    {
        if (_vision.IsSeeing)
        {
            if (_follower.IsFollow(_vision.GetTargetTransform()))
            {
                _rotator.RotateTowards(_vision.GetTargetTransform());
                _mover.Move(_follower.GetDirection(_vision.GetTargetTransform()));
            }
            else
            {
                if (_damager.CanAttack(_vision.GetTargetTransform(), out Health health)) 
                    _damager.Attack(health);
            }
        }
        else
        {
            _rotator.RotateTowards(_patroler.GetPatrolPoint());
            _mover.Move(_patroler.GetDirection());
        }
    }
}
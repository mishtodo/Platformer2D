using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyDamager _damager;
    [SerializeField] private Patrol _patrol;
    [SerializeField] private Vision _vision;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
        _damager = GetComponent<EnemyDamager>();
        _patrol = GetComponent<Patrol>();
        _vision = GetComponent<Vision>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
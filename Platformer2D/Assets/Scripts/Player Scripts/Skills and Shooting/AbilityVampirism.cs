using UnityEngine;

public class AbilityVampirism : MonoBehaviour 
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _overlapRadus = 2.5f;
    [SerializeField] private int _minDamageAmount = 1;

    private Collider2D _enemyCollider2D;
    private Vector2 _center;

    public void StealLife()
    {
        _center = transform.parent.transform.position;
        _enemyCollider2D = FindClosestEnemy();

        if (_enemyCollider2D != null && _enemyCollider2D.TryGetComponent<Health>(out Health enemyHealth))
        {
            enemyHealth.TakeDamage(_minDamageAmount);
            _playerHealth.TakeHeal(_minDamageAmount);
        }
    }

    private Collider2D FindClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(_center, _overlapRadus, _enemy);

        Collider2D closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector2.SqrMagnitude((Vector2)enemy.transform.position - _center);

            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
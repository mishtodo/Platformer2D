using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] _enemies;

    private void Awake()
    {
        foreach (Enemy enemy in _enemies) 
        {
            enemy.TryGetComponent<Health>(out Health health);
            health.Dying += DestroyEnemy;
        }
    }

    private void DestroyEnemy(Health health)
    {
        health.Dying -= DestroyEnemy;
        Destroy(health.gameObject);
    }
}
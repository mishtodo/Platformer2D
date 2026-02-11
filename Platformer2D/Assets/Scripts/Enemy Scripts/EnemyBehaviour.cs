using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyFollower))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyFollower _enemyFollower;
    [SerializeField] private EnemyMover _enemyMover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemyFollower.SetFollowing(true);
            _enemyMover.SetMoving(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemyFollower.SetFollowing(false);
            _enemyMover.SetMoving(true);
        }
    }
}
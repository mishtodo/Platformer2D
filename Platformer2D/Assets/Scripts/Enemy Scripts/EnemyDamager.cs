using System.Collections;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _overlapRadius = 1.25f;
    [SerializeField] private float _attackDelay = 1.0f;
    [SerializeField] private LayerMask _player;

    private Vector2 _center;
    private Collider2D _collider;
    private Coroutine _coroutine;

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopCoroutine();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartCoroutine()
    {
        _coroutine = StartCoroutine(DealDamage());
    }

    private IEnumerator DealDamage()
    {
        var wait = new WaitForSecondsRealtime(_attackDelay);
        _center = new(transform.position.x, transform.position.y);
        _collider = Physics2D.OverlapCircle(_center, _overlapRadius, _player);

        if (_collider.gameObject.TryGetComponent<Player>(out Player player))
            if (player.TryGetComponent<Health>(out Health health))
                health.TakeDamage(_damageAmount);

        yield return wait;
    }
}

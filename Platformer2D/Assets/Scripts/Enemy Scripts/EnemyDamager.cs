using System.Collections;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 5;
    [SerializeField] private float _attackDelay = 1.0f;

    private Coroutine _coroutine;

    public void Attack(Health health)
    {
        if (_coroutine == null)
            StartCoroutine(health);
    }

    public bool CanAttack(Transform transform, out Health health)
    {
        return transform.TryGetComponent<Health>(out health);
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartCoroutine(Health health)
    {
        _coroutine = StartCoroutine(DealDamage(health));
    }

    private IEnumerator DealDamage(Health health)
    {
        var wait = new WaitForSecondsRealtime(_attackDelay);

        health.TakeDamage(_damageAmount);

        yield return wait;

        _coroutine = null;
    }
}

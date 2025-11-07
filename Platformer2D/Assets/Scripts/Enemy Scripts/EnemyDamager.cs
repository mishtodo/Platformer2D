using System.Collections;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _attackDelay = 1.0f;

    private Coroutine _coroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            StartCoroutine(playerHealth);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopCoroutine();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartCoroutine(PlayerHealth playerHealth)
    {
        _coroutine = StartCoroutine(DealDamage(playerHealth));
    }

    private IEnumerator DealDamage(PlayerHealth playerHealth)
    {
        var wait = new WaitForSecondsRealtime(_attackDelay);

        while(enabled)
        {
            playerHealth.TakeDamage(_damageAmount);
            yield return wait;
        }
    }
}

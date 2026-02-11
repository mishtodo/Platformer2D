using System.Collections;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _attackDelay = 1.0f;

    private Coroutine _coroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(player);
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

    public void StartCoroutine(Player player)
    {
        _coroutine = StartCoroutine(DealDamage(player));
    }

    private IEnumerator DealDamage(Player player)
    {
        var wait = new WaitForSecondsRealtime(_attackDelay);

        while(enabled)
        {
            player.GetComponent<Health>().TakeDamage(_damageAmount);
            yield return wait;
        }
    }
}

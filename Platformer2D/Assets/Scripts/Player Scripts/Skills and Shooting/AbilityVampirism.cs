using UnityEngine;
using System.Collections;

public class AbilityVampirism : MonoBehaviour 
{
    [SerializeField] private LayerMask _player;
    [SerializeField] private LayerMask _enemy;

    private Coroutine _coroutine;
    private Collider2D _enemyCollider2D;
    private Collider2D _playerCollider2D;
    private Vector2 _center;

    public bool IsLifeStealing { get; private set; }

    public void StealLife()
    {
        if (_coroutine == null)
            StartCoroutine();
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(CheckPlayerDelayed());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(CheckPlayerDelayed());
    }

    private IEnumerator CheckPlayerDelayed()
    {
        var wait = new WaitForSecondsRealtime(0.5f);

        while (enabled)
        {
            _center = transform.parent.transform.position;
            _playerCollider2D = Physics2D.OverlapCircle(_center, 10, _player);
            Debug.Log(_center.x.ToString() + "/" + _center.y.ToString());
            _enemyCollider2D = Physics2D.OverlapCircle(_center, 10, _enemy);

            _enemyCollider2D.TryGetComponent<Health>(out Health health); 
            health.TakeDamage(3);

            //IsLifeStealing = _enemyCollider2D != null;

            yield return wait;
        }

        _coroutine = null;
    }

    public Transform GetPlayerTransform()
    {
        return _playerCollider2D.transform;
    }

    public Transform GetEnemyTransform()
    {
        return _enemyCollider2D.transform;
    }
}
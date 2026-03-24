using UnityEngine;
using System.Collections;

public class AbilityVampirism : MonoBehaviour 
{
    [SerializeField] private LayerMask _player;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _overlapRadus = 2.5f;

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
        _coroutine = StartCoroutine(StealLifeRoutine());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(StealLifeRoutine());
    }

    private IEnumerator StealLifeRoutine()
    {
        var wait = new WaitForSecondsRealtime(0.3f);

        while (enabled)
        {
            _center = transform.parent.transform.position;
            //Debug.Log(_center.x.ToString() + "/" + _center.y.ToString());
            _enemyCollider2D = Physics2D.OverlapCircle(_center, _overlapRadus, _enemy);
            _playerCollider2D = Physics2D.OverlapCircle(_center, _overlapRadus, _player);

            if (_enemyCollider2D != null && _playerCollider2D != null)
            {
                if(_enemyCollider2D.TryGetComponent<Health>(out Health enemyHealth))
                {
                    enemyHealth.TakeDamage(1);

                    if (_playerCollider2D.TryGetComponent<Health>(out Health playerHealth))
                    {
                        playerHealth.TakeHeal(1);
                    }
                }
            }

            //IsLifeStealing = _enemyCollider2D != null;

            yield return wait;
            _coroutine = null;
            //Debug.Log("while enabled?");
        }
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
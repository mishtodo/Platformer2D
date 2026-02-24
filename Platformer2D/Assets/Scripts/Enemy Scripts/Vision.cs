using System.Collections;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private float _overlapRadius = 3.0f;
    [SerializeField] private float _checkingDelay = 0.25f;
    [SerializeField] private LayerMask _player;

    private Collider2D _collider;
    private Vector2 _center;
    private Coroutine _coroutine;

    public bool IsSeeing { get; private set; }

    private void Start()
    {
        StartCoroutine();
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(CheckPlayer());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(CheckPlayer());
    }

    private IEnumerator CheckPlayer()
    {
        var wait = new WaitForSecondsRealtime(_checkingDelay);

        while (enabled)
        {
            _center = new(transform.position.x, transform.position.y);
            _collider = Physics2D.OverlapCircle(_center, _overlapRadius, _player);
            IsSeeing = _collider != null;

            yield return wait;
        }
    }

    public Collider2D GetTarget()
    {
        return _collider;
    }
}

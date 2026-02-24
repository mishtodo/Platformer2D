using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _overlapRadius = 0.45f;
    [SerializeField] private Vector2 _offset = new(0, -0.125f);
    [SerializeField] private float _checkingDelay = 0.25f;
    [SerializeField] private LayerMask _groundLayer;

    private Collider2D _collider;
    private Vector2 _center;
    private Coroutine _coroutine;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        StartCoroutine();
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(CheckGround());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(CheckGround());
    }

    private IEnumerator CheckGround()
    {
        var wait = new WaitForSecondsRealtime(_checkingDelay);

        while (enabled) 
        { 
            _center = new(transform.position.x, transform.position.y);
            _collider = Physics2D.OverlapCircle(_center + _offset, _overlapRadius, _groundLayer);
            IsGrounded = _collider != null;

            yield return wait;
        }
    }
}
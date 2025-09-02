using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 0.75f;

    private RaycastHit2D _hitInfo;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        _hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance);

        if (_hitInfo)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
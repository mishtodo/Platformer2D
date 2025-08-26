using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 0.75f;

    private RaycastHit2D _hitInfo;
    private bool _isGrounded;

    public event Action<bool> Grounded;

    private void FixedUpdate()
    {
        _hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance);

        if (_hitInfo)
        {
            _isGrounded = true;
            Grounded?.Invoke(_isGrounded);
        }
        else
        {
            _isGrounded = false;
            Grounded?.Invoke(_isGrounded);
        }
    }
}
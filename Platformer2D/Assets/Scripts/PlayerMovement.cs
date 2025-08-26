using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 _direction;

    public event Action<float> ChangingDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        ChangingDirection?.Invoke(_direction.x);
        _rigidbody.position += _direction * _speed * Time.deltaTime;
    }
}
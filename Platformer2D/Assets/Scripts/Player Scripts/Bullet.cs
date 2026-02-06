using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 20;

    public Action<Bullet> Dying;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth resource))
        {
            resource.TakeDamage(_bulletDamage);
        }

        if (collision.gameObject.TryGetComponent<PlayerHealth>(out _) == false)
            Dying?.Invoke(this);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void InitializeVelocity(Vector3 velocity)
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void InitializePosition(Vector3 position)
    {
        transform.position = position;
    }

    public void InitializeRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}

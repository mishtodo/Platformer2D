using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 20;

    public Action<Bullet> Dying;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(_bulletDamage);
        }

        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth) == false)
            Dying?.Invoke(this);
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
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

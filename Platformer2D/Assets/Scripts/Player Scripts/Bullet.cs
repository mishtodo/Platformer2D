using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 20;

    public Action<Bullet> Dying;

    private void OnCollision2DEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            enemyHealth.TakeDamage(_bulletDamage);

        Dying?.Invoke(this);
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
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

using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int _healAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.Heal(_healAmount);
            Destroy(this.gameObject);
        }
    }
}
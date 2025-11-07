using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int _healAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.Heal(_healAmount);
            Destroy(this.gameObject);
        }
    }
}
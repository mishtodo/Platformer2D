using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private HealthPackCollector _healthPackCollector;
    [SerializeField] private int _healAmount = 10;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        RedirectLogic(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RedirectLogic(collision.gameObject);
    }

    private void RedirectLogic(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                CollectCoin(obj);
                break;

            case "Medkit":
                UseMedkit(obj);
                break;

            case "EnemyBullet":
                TakeDamage(obj);
                break;

            default:
                break;
        }
    }

    private void CollectCoin(GameObject coin)
    {
        Destroy(coin);
    }

    private void UseMedkit(GameObject kit)
    {
        _health?.Heal(_healAmount);
        Destroy(kit);
    }

    private void TakeDamage(GameObject bullet)
    {
        Destroy(bullet);
    }
}
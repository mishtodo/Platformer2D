using UnityEngine;

[RequireComponent(typeof(CoinCollector), typeof(HealthPackCollector))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private HealthPackCollector _healthPackCollector;

    private void Awake()
    {
        _coinCollector = GetComponent<CoinCollector>();
        _healthPackCollector = GetComponent<HealthPackCollector>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out _))
            { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthPack>(out HealthPack healthPack))
        {
            healthPack.Collected();
            _healthPackCollector.Collect(collision.gameObject);
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collected();
            _coinCollector.Collect(collision.gameObject);
        }
    }    
}
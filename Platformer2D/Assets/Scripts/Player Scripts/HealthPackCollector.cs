using UnityEngine;

public class HealthPackCollector : MonoBehaviour
{
    [SerializeField] Health _health;

    [SerializeField] private int _healAmount = 10;

    public void Heal()
    {
        _health.Heal(_healAmount);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent<HealthPack>(out _))
    //        Destroy(collision.gameObject);
    //}
}

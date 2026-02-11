using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthPackCollector : MonoBehaviour
{
    [SerializeField] HealthPackSpawner _healthPackSpawner;
    [SerializeField] Health _health;
    [SerializeField] private int _healAmount = 10;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Collect(GameObject obj) 
    {
        Heal();
        Destroy(obj);
    }

    private void Heal()
    {
        _health.Heal(_healAmount);
    }
}
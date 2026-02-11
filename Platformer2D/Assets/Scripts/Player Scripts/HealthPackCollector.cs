using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthPackCollector : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] private int _healAmount = 10;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Collect(HealthPack healthPack) 
    {
        Heal();
        healthPack.Collected();
    }

    private void Heal()
    {
        _health.Heal(_healAmount);
    }
}
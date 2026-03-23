using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthPackCollector : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _healAmount = 10;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Collect(HealthPack healthPack) 
    {
        TakeHeal();
        healthPack.Collected();
    }

    private void TakeHeal()
    {
        _health.TakeHeal(_healAmount);
    }
}
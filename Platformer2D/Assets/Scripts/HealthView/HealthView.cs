using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += UpdateHealth;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateHealth;
    }

    protected virtual void Start()
    {
        UpdateHealth(Health.Max);
    }

    public virtual void UpdateHealth(int currentHealth) { }
}
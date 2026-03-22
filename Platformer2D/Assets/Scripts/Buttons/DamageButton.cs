public class DamageButton : HealthButton
{
    private void OnEnable()
    {
        Button.onClick.AddListener(ReduceHealth);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(ReduceHealth);
    }

    public void ReduceHealth()
    {
        Health.TakeDamage(HealthChangeValue);
    }
}
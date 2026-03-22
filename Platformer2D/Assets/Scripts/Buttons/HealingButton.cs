public class HealingButton : HealthButton
{
    private void OnEnable()
    {
        Button.onClick.AddListener(AddHealth);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(AddHealth);
    }

    public void AddHealth()
    {
        Health.TakeHeal(HealthChangeValue);
    }
}
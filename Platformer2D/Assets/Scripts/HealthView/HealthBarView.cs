public class HealthBarView : HealthViewSlider
{
    public override void UpdateHealth(int currentHealth)
    {
        HealthSlider.value = currentHealth;
    }
}
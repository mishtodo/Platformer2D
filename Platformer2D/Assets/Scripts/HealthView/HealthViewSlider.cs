using UnityEngine;
using UnityEngine.UI;

public abstract class HealthViewSlider : HealthView
{
    [SerializeField] protected Slider HealthSlider;

    protected override void Start()
    {
        HealthSlider.maxValue = Health.Max;
        HealthSlider.minValue = 0;
        UpdateHealth(Health.Max);
    }
}
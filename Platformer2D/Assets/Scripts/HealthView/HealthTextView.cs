using UnityEngine;
using TMPro;

public class HealthTextView : HealthView
{
    private const char TextParser = '/';

    [SerializeField] private TextMeshProUGUI _healthText;

    public override void UpdateHealth(int currentHealth)
    {
        _healthText.text = currentHealth.ToString() + TextParser + Health.Max.ToString();
    }
}
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private Slider _cooldownSlider;
    [SerializeField] private float _sliderMaxValue = 1.0f;
    [SerializeField] private float _sliderMinValue = 0.0f;

    public void UpdateReload(bool IsRunning, float noralizedPosition)
    {
        if (IsRunning)
            _cooldownSlider.value = Mathf.Lerp(_sliderMinValue, _sliderMaxValue, noralizedPosition);
        else
            _cooldownSlider.value = Mathf.Lerp(_sliderMaxValue, _sliderMinValue, noralizedPosition);
    }
}
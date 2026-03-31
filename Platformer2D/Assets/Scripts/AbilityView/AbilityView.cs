using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private Slider _cooldownSlider;
    [SerializeField] private float _sliderMaxValue = 1.0f;
    [SerializeField] private float _sliderMinValue = 0.0f;

    private Coroutine _coroutine;

    public void UpdateReload(bool IsRunning, float durationTime)
    {
        if (IsRunning)
        {
            StopCoroutine();
            StartCoroutine(_sliderMaxValue, durationTime);
        }
        else
        {
            StopCoroutine();
            StartCoroutine(_sliderMinValue, durationTime);
        }
    }

    public void StartCoroutine(float target, float smoothDuration)
    {
        _coroutine = StartCoroutine(ChangeReloadSmoothly(target, smoothDuration));
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChangeReloadSmoothly(float target, float smoothDuration)
    {
        float distance = Mathf.Abs(_cooldownSlider.value - target);
        float speed = distance / smoothDuration;

        while (_cooldownSlider.value != target)
        {
            _cooldownSlider.value = Mathf.MoveTowards(_cooldownSlider.value, target, Time.deltaTime * speed);

            yield return null;
        }
    }
}
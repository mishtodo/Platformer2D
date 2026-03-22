using System.Collections;
using UnityEngine;

public class HealthBarSmoothView : HealthViewSlider
{
    [SerializeField] private float _smoothDuration = 0.5f;

    private Coroutine _coroutine;

    public override void UpdateHealth(int currentHealth)
    {
        StopCoroutine();
        StartCoroutine(currentHealth);
    }

    public void StartCoroutine(float target)
    {
        _coroutine = StartCoroutine(ChangeHealthSmoothly(target));
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChangeHealthSmoothly(float target)
    {
        float distance = Mathf.Abs(HealthSlider.value - target);
        float speed = distance / _smoothDuration;

        while (HealthSlider.value != target)
        {
            HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, target, Time.deltaTime * speed);

            yield return null;
        }
    }
}
using System.Collections;
using UnityEngine;

public class AbilityViewVampirism : AbilityView
{
    [SerializeField] private float _smoothDuration = 0.5f;

    private Coroutine _coroutine;

    public override void UpdateReload()
    {
        if (Ability.IsRunning)
        {
            StopCoroutine();
            StartCoroutine(Ability.Duration);
        }
        else
        {
            StopCoroutine();
            StartCoroutine(Ability.Cooldown);
        }
    }


    public void StartCoroutine(float target)
    {
        _coroutine = StartCoroutine(ChangeReloadSmoothly(target));
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChangeReloadSmoothly(float target)
    {
        float distance = Mathf.Abs(CooldownSlider.value - target);
        float speed = distance / _smoothDuration;

        while (CooldownSlider.value != target)
        {
            CooldownSlider.value = Mathf.MoveTowards(CooldownSlider.value, target, Time.deltaTime * speed);

            yield return null;
        }
    }
}
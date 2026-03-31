using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] private float _duration = 6.0f;
    [SerializeField] private float _cooldown = 4.0f;
    [SerializeField] private AbilityVampirism _vampirism;
    [SerializeField] private AbilityView _abilityView;

    private Coroutine _coroutine;
    
    public bool IsRunning { get; private set; }

    private void Start()
    {
        IsRunning = false;
    }

    public void StartAbility()
    {
        if (_coroutine == null)
            StartCoroutine();
    }

    public void StartCoroutine()
    {
        _coroutine = StartCoroutine(Vampirism());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Vampirism()
    {
        var wait = new WaitForSecondsRealtime(_duration);
        IsRunning = true;
        _vampirism.gameObject.SetActive(true);
        _abilityView.UpdateReload(IsRunning, _duration);
        _vampirism.StealLife();

        yield return wait;

        wait = new WaitForSecondsRealtime(_cooldown);
        _vampirism.gameObject.SetActive(false);
        IsRunning = false;
        _abilityView.UpdateReload(IsRunning, _cooldown);

        yield return wait;
        _coroutine = null;
    }
}
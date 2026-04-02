using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] private float _duration = 6.0f;
    [SerializeField] private float _cooldown = 4.0f;
    [SerializeField] private float _totalDamage = 20.0f;
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
        float elapsedTime = 0;
        float timeTick = 0;

        IsRunning = true;
        _vampirism.gameObject.SetActive(true);

        while (elapsedTime <= _duration)
        {
            if(elapsedTime >= timeTick)
            {
                _vampirism.StealLife();
                timeTick += _duration / _totalDamage;
            }

            elapsedTime += Time.deltaTime;
            _abilityView.UpdateReload(IsRunning, elapsedTime / _duration);
            yield return null;
        }
        
        _vampirism.gameObject.SetActive(false);
        IsRunning = false;
        elapsedTime = 0;

        while (elapsedTime < _cooldown)
        {
            _abilityView.UpdateReload(IsRunning, elapsedTime / _cooldown);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _coroutine = null;
    }
}
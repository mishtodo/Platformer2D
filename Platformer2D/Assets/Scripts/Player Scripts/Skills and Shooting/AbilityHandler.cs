using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] private float _cooldown = 2.0f;
    [SerializeField] private AbilityVampirism _vampirism;

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
        IsRunning = true;
        _vampirism.gameObject.SetActive(true);
        var wait = new WaitForSecondsRealtime(_duration);

        //Debug.Log(IsRunning);

        _vampirism.StealLife();

        yield return wait;

        _vampirism.gameObject.SetActive(false);

        wait = new WaitForSecondsRealtime(_cooldown);

        yield return wait;

        IsRunning = false;
        _coroutine = null;

        //Debug.Log(IsRunning);
    }
}

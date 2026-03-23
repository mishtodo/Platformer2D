using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] private float _calldown = 1.0f;
    [SerializeField] private AbilityVampirism _vampirism;

    private Coroutine _coroutine;
    
    public bool IsRunning { get; private set; }

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
        _vampirism.gameObject.SetActive(true);
        var wait = new WaitForSecondsRealtime(_duration + _calldown);

        yield return wait;

        _vampirism.gameObject.SetActive(false);
        _coroutine = null;
    }
}

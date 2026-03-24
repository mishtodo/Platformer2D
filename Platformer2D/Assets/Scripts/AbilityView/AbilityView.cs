using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityView : MonoBehaviour
{
    [SerializeField] protected AbilityHandler AbilityHandler;
    [SerializeField] protected Ability Ability;
    [SerializeField] protected Slider CooldownSlider;

    private void OnEnable()
    {
        Ability.StateChanged += UpdateReload;
    }

    private void OnDisable()
    {
        Ability.StateChanged -= UpdateReload;
    }

    public virtual void UpdateReload() { }
}

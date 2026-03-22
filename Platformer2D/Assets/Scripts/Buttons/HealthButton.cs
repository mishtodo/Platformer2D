using UnityEngine.UI;
using UnityEngine;

public abstract class HealthButton : MonoBehaviour
{
    [SerializeField] protected int HealthChangeValue;
    [SerializeField] protected Health Health;
    [SerializeField] protected HealthTextView HealthTextView;
    [SerializeField] protected HealthBarView HealthBarView;
    [SerializeField] protected HealthBarSmoothView HealthBarSmoothView;
    [SerializeField] protected Button Button;
}
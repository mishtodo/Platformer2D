using System;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public event Action StateChanged;

    public bool IsRunning { get; private set; }
    public float Duration { get; private set; }
    public float Cooldown { get; private set; }
}
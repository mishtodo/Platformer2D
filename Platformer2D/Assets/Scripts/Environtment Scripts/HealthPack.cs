using System;
using UnityEngine;

public class HealthPack : MonoBehaviour 
{
    public event Action<HealthPack> Dying;

    public void Collected()
    {
        Dying?.Invoke(this);
    }
}
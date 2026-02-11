using System;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    public event Action<Coin> Dying;

    public void Collected()
    {
        Dying?.Invoke(this);
    }
}
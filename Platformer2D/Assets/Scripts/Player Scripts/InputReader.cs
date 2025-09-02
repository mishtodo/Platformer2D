using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float DirectionX { get; private set; }
    public event Action Moving;
    public event Action Jumping;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jumping?.Invoke();

        DirectionX = Input.GetAxisRaw("Horizontal");
        Moving?.Invoke();
    }
}
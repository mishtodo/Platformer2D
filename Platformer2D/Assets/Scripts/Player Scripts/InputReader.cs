using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public float DirectionX { get; private set; }
    public event Action Moving;
    public event Action Jumping;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jumping?.Invoke();

        DirectionX = Input.GetAxisRaw(Horizontal);
        Moving?.Invoke();
    }
}
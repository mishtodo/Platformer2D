using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    private bool _isShooting;

    public float DirectionX { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _isShooting = true;

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;

        DirectionX = Input.GetAxisRaw(Horizontal);
    }

    public bool GetIsShooting() => GetBoolAsTrigger(ref _isShooting);
    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
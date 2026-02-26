using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animations : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool(IsGrounded, isGrounded);
    }
}
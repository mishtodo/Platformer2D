using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

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
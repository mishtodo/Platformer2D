using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class EnemyFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private float _speed = 4.0f;

    private bool _isFollowing = false;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        if (_isFollowing) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            _rotator.RotateTowards(_target);
        }
    }

    public void SetFollowing(bool isFollowing)
    {
        _isFollowing = isFollowing;
    }
}
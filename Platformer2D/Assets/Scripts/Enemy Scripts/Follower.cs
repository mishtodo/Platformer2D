using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _arrivalDistance = 1.5f;

    public bool IsFollowing { get; private set; }

    private void Awake()
    {
        IsFollowing = false;
    }

    public bool IsFollow(Transform target)
    {
        if (Vector2.SqrMagnitude(target.position - transform.position) < _arrivalDistance * _arrivalDistance || target == null)
            return false;
        else
            return true;
    }

    public float GetDirection(Transform target)
    {
        float direction = (target.position - transform.position).normalized.x;
        return direction;
    }
}
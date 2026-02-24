using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyDamager _damager;

    private float _arrivalDistance = 1.0f;

    public void Follow(Transform target)
    {
        if (target != null)
        {
            if (Vector2.SqrMagnitude(target.position - transform.position) < _arrivalDistance)
            {     
                _damager.StartCoroutine();
            }
            else
            {
                _damager.StopCoroutine();
                _mover.Move(GetDirection(target));
            }
        }
    }

    public float GetDirection(Transform target)
    {
        float direction = (target.position - transform.position).normalized.x;
        return direction;
    }
}
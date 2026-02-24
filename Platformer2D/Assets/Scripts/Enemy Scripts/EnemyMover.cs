using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    public void MoveTowards(Transform currentWaypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);
    }
}
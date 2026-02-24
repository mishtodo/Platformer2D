using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private int _currentWaypointIndex = 0;
    private float _arrivalDistance = 0.5f;

    public Transform GetPatrolPoint()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];

        if (Vector2.SqrMagnitude(currentWaypoint.position - transform.position) < _arrivalDistance)
            _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;

        return currentWaypoint;
    }

    public float GetDirection()
    {
        float direction = (GetPatrolPoint().position - transform.position).normalized.x;
        return direction;
    }
}

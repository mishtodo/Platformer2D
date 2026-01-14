using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private float _speed = 5.0f;

    private int _currentWaypointIndex = 0;
    private bool _isMoving = true;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            Transform currentWaypoint = _waypoints[_currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);
            _rotator.RotateTowards(currentWaypoint);

            if (transform.position == currentWaypoint.position)
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }

    public void SetMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }
}
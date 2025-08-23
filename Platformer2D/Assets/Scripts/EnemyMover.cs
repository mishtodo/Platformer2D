using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 5.0f;

    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length; 
        
        if (transform.position.x < currentWaypoint.position.x)
            _spriteRenderer.flipX = true;
        else 
            _spriteRenderer.flipX = false;
    }
}
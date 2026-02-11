using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Quaternion _rightRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion _leftRotation = Quaternion.Euler(0, 180, 0);

    public void RotateRight()
    {
        if (transform.rotation != _rightRotation)
            transform.rotation = _rightRotation;
    }

    public void RotateLeft() 
    {
        if (transform.rotation != _leftRotation)
            transform.rotation = _leftRotation;
    }

    public void RotateTowards(Transform target)
    {
        if (transform.position.x > target.position.x)
            RotateRight();
        else if (transform.position.x < target.position.x)
            RotateLeft();
    }

    public void RotateTowardsDirection(float direction)
    {
        if (direction > 0)
            RotateRight();
        else
            RotateLeft();
    }
}
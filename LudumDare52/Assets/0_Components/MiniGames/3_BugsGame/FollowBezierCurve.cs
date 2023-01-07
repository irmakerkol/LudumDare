using UnityEngine;
using PathCreation;

public class FollowBezierCurve : MonoBehaviour
{
    public PathCreator curve; // Reference to the Bézier curve
    public float speed = 1.0f; // Speed at which the object moves along the curve

    void Update()
    {
        // Calculate the position and direction on the curve at a given time
        Vector3 position = curve.path.GetPointAtTime(Time.time * speed);
        Vector3 direction = curve.path.GetDirection(Time.time * speed);

        // Set the position and rotation of the game object
        transform.position = position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
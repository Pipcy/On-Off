using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints to move the camera to
    public GameObject target; // Target GameObject to always point at
    public float speed = 2f; // Speed of camera movement

    private int currentWaypointIndex = 0; // Index of current waypoint

    private void Update()
    {
        // Check if there are waypoints defined
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints defined!");
            return;
        }

        // Get the current waypoint
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // Calculate the direction to the current waypoint
        Vector3 direction = currentWaypoint.position - transform.position;

        // Move the camera towards the current waypoint
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Check if the camera has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f)
        { }

        // Check if the camera has reached the current waypoint
        if (Input.GetKeyDown(KeyCode.Space))
        {
                // Move to the next waypoint
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Point the camera at the target GameObject
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
    }
}

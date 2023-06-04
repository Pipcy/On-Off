//using UnityEngine;

//public class CameraMovement : MonoBehaviour
//{
//    public Transform[] waypoints; // Array of waypoints to move the camera to
//    public GameObject target; // Target GameObject to always point at
//    public float speed = 2f; // Speed of camera movement

//    private int currentWaypointIndex = 0; // Index of current waypoint
//    private int targetWaypointIndex = 0;

//    public Transform playerLoc;
//    public GameObject wall0;
//    public GameObject wall1;
//    public GameObject wall2;
//    public GameObject wall3;

//    private void Update()
//    {
//        // Check if there are waypoints defined
//        if (waypoints.Length == 0)
//        {
//            Debug.LogWarning("No waypoints defined!");
//            return;
//        }

//        // Point the camera at the target GameObject
//        if (target != null)
//        {
//            transform.LookAt(target.transform);
//        }

//        // Get the current waypoint
//        Transform currentWaypoint = waypoints[currentWaypointIndex];

//        // Calculate the direction to the current waypoint
//        Vector3 direction = currentWaypoint.position - transform.position;

//        // Move the camera towards the current waypoint
//        //if(Vector3.Distance(transform.position, currentWaypoint.position) > 0.1f)
//        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

//        // Check if the camera has reached the current waypoint
//        if (currentWaypointIndex == targetWaypointIndex)
//        {
//            // Stop camera movement
//            transform.position = currentWaypoint.position;
//        }

//        if (currentWaypointIndex != targetWaypointIndex) //Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f &&
//        {
//            // Move to the next waypoint
//            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
//        } 


//        //-------- Player Location Determining Target Waypoint --------------
//        if (playerLoc.position.x > 0.5 && playerLoc.position.z > 0.5)
//        {
//            targetWaypointIndex = 3;
//            wall0.SetActive(false);
//            wall1.SetActive(true);
//            wall2.SetActive(false);
//            wall3.SetActive(true);
//        }
//        else if (playerLoc.position.x < -0.5 && playerLoc.position.z < -0.5)
//        {
//            targetWaypointIndex = 1;
//            wall0.SetActive(true);
//            wall1.SetActive(false);
//            wall2.SetActive(true);
//            wall3.SetActive(false);
//        }
//        else if (playerLoc.position.x < -0.5 && playerLoc.position.z > 0.5)
//        {
//            targetWaypointIndex = 2;
//            wall0.SetActive(true);
//            wall1.SetActive(false);
//            wall2.SetActive(false);
//            wall3.SetActive(true);
//        }
//        else if (playerLoc.position.x > 0.5 && playerLoc.position.z < -0.5)
//        {
//            targetWaypointIndex = 0;
//            wall0.SetActive(false);
//            wall1.SetActive(true);
//            wall2.SetActive(true);
//            wall3.SetActive(false);
//        }


//    }
//}


using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints to move the camera to
    public GameObject target; // Target GameObject to always point at
    public float speed = 2f; // Speed of camera movement

    //-------- camera movement ------------
    private int currentWaypointIndex = 0; // Index of current waypoint
    private int targetWaypointIndex = 0;
    private bool isMoving = true; // Flag to control camera movement
    private float point_cam_dis = 0f;

    public Transform playerLoc;
    public GameObject wall0;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;


    //--------- camera zooming ------------
    public float zoomSpeed = 5f; // Speed of camera zoom
    public float minZoomDistance = 1f; // Minimum zoom distance
    public float maxZoomDistance = 10f; // Maximum zoom distance
    private float currentZoomDistance = 5f; // Initial zoom distance
    public float zoomDelay = 0.5f;
    private float zoomTimer = 0f;

    private void Update()
    {
        // Check if there are waypoints defined
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints defined!");
            return;
        }

        // Point the camera at the target GameObject
        if (target != null)
        {
            transform.LookAt(target.transform);
        }

        Debug.Log(isMoving);
        
        HandleZoom();

        if (currentWaypointIndex != targetWaypointIndex)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            currentWaypointIndex = targetWaypointIndex;
            // Get the current waypoint
            Transform currentWaypoint = waypoints[currentWaypointIndex];

            // Calculate the direction to the current waypoint
            Vector3 direction = currentWaypoint.position - transform.position;

            // Move the camera towards the current waypoint
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            point_cam_dis = Vector3.Distance(transform.position, currentWaypoint.position);
            Debug.Log(point_cam_dis);

            if (point_cam_dis <= 0.05f)
            {
                isMoving = false;
            }

            //// Check if the camera has reached the current waypoint
            //if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f)
            //{
            //    // Check if the current waypoint is the target waypoint
            //    if (currentWaypointIndex == targetWaypointIndex)
            //    {
            //        // Stop camera movement
            //        isMoving = false;
            //    }
            //    else
            //    {
            //        // Move to the next waypoint
            //        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            //    }
            //}
        }

        if(point_cam_dis <= 3f )
        {
            if(targetWaypointIndex == 3)
            {
                wall1.SetActive(true);
                wall3.SetActive(true);
            }
            else if (targetWaypointIndex == 1)
            {
                wall0.SetActive(true);
                wall2.SetActive(true);
            }
            else if (targetWaypointIndex == 2)
            {
                wall0.SetActive(true);
                wall3.SetActive(true);
            }
            else if (targetWaypointIndex == 0)
            {
                wall1.SetActive(true);
                wall2.SetActive(true);
            }
        }







        if (playerLoc.position.x > 1 && playerLoc.position.z > 1)
        {
            targetWaypointIndex = 3;
            wall0.SetActive(false);
            //wall1.SetActive(true);
            wall2.SetActive(false);
            //wall3.SetActive(true);
        }
        else if (playerLoc.position.x < -1 && playerLoc.position.z < -1)
        {
            targetWaypointIndex = 1;
            //wall0.SetActive(true);
            wall1.SetActive(false);
            //wall2.SetActive(true);
            wall3.SetActive(false);
        }
        else if (playerLoc.position.x < -1 && playerLoc.position.z > 1)
        {
            targetWaypointIndex = 2;
            //wall0.SetActive(true);
            wall1.SetActive(false);
            wall2.SetActive(false);
            //wall3.SetActive(true);
        }
        else if (playerLoc.position.x > 1 && playerLoc.position.z < -1)
        {
            targetWaypointIndex = 0;
            wall0.SetActive(false);
            //wall1.SetActive(true);
            //wall2.SetActive(true);
            wall3.SetActive(false);
        }
    }


    private void HandleZoom()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= scrollDelta * zoomSpeed;

        // Clamp the zoom distance to the defined range
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // Set the camera position based on the zoom distance
        Vector3 zoomVector = -transform.forward * currentZoomDistance;
        transform.position = target.transform.position + zoomVector;

    }
}

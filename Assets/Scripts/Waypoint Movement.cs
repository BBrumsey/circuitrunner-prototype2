using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 4;

    private int currentWaypoint = 0;
    void Start()
    {
        if (waypoints.Length > 0) 
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (currentWaypoint >= waypoints.Length)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,
          waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, 
            waypoints[currentWaypoint].position) < 0.05f)
        {
            currentWaypoint++;
        
            if (currentWaypoint >= waypoints.Length)
            {
                Debug.Log("Circuit Complete"!);
                enabled = false;
            }
            

        }
    }
}

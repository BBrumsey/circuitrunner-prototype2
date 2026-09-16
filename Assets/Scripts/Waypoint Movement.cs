using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 4f;

    private int currentWaypoint = 0;
    private int targetWaypoint = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(
            horizontalInput,
            verticalInput
        );

        if (input.sqrMagnitude == 0)
        {
            return;
        }

        input.Normalize();

        bool betweenWaypoints = Vector2.Distance(
            transform.position,
            waypoints[currentWaypoint].position
        ) > 0.05f;

        // Reverse toward the last waypoint.
        if (betweenWaypoints &&
            DirectionMatches(currentWaypoint, input))
        {
            targetWaypoint = currentWaypoint;
        }
        // Move to the next waypoint.
        else if (DirectionMatches(currentWaypoint + 1, input))
        {
            targetWaypoint = currentWaypoint + 1;
        }
        // Move to the previous waypoint.
        else if (DirectionMatches(currentWaypoint - 1, input))
        {
            targetWaypoint = currentWaypoint - 1;
        }
        else
        {
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[targetWaypoint].position,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(
            transform.position,
            waypoints[targetWaypoint].position) < 0.05f)
        {
            transform.position = waypoints[targetWaypoint].position;
            currentWaypoint = targetWaypoint;
        }
    }

    public void ResetToStart()
    {
        currentWaypoint = 0;
        targetWaypoint = 0;
        transform.position = waypoints[0].position;
    }

    bool DirectionMatches(int waypointIndex, Vector2 input)
    {
        if (waypointIndex < 0 ||
            waypointIndex >= waypoints.Length)
        {
            return false;
        }

        Vector2 directionToWaypoint =
            ((Vector2)waypoints[waypointIndex].position -
            (Vector2)transform.position).normalized;

        return Vector2.Dot(input, directionToWaypoint) > 0.7f;
    }
}
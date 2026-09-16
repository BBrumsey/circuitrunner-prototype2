using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 4f;

    private int currentWaypoint = 0;
    private int targetWaypoint = 0;

    void Start()
    {
        ResetToStart();
    }

    void Update()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (input.sqrMagnitude == 0)
        {
            return;
        }

        input.Normalize();

        // The player is currently sitting on a waypoint.
        if (currentWaypoint == targetWaypoint)
        {
            if (DirectionMatches(currentWaypoint + 1, input))
            {
                targetWaypoint = currentWaypoint + 1;
            }
            else if (DirectionMatches(currentWaypoint - 1, input))
            {
                targetWaypoint = currentWaypoint - 1;
            }
            else
            {
                return;
            }
        }
        // The player is currently between two waypoints.
        else
        {
            if (DirectionMatches(targetWaypoint, input))
            {
                // Continue toward the target.
            }
            else if (DirectionMatches(currentWaypoint, input))
            {
                // Reverse along the same circuit segment.
                int oldCurrent = currentWaypoint;
                currentWaypoint = targetWaypoint;
                targetWaypoint = oldCurrent;
            }
            else
            {
                return;
            }
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

    public void ResetToStart()
    {
        currentWaypoint = 0;
        targetWaypoint = 0;

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }
}
using UnityEngine;

public class CircuitLineRenderer : MonoBehaviour
{
    public Transform[] waypoints;

    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = waypoints.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, waypoints[i].position);
        }
    }
}
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class CircuitLineRenderer : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField] private float lineYOffset = 0f;

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        if (waypoints == null || waypoints.Length < 2)
        {
            lineRenderer.positionCount = 0;
            return;
        }

        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = waypoints.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null)
            {
                lineRenderer.positionCount = 0;
                return;
            }

            lineRenderer.SetPosition(
                i, waypoints[i].position + Vector3.up * lineYOffset
            );
        }
    }
}
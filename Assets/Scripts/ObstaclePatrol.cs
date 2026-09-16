using UnityEngine;

public class ObstaclePatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }
}
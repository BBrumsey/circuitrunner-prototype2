using UnityEngine;

public class GoalComplete : MonoBehaviour
{
    public GameObject circuitCompleteScreen;

    void Start()
    {
        circuitCompleteScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            circuitCompleteScreen.SetActive(true);

            WaypointMovement movement =
                other.GetComponent<WaypointMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }
        }
    }
}
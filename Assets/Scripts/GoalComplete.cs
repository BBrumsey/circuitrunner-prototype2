using UnityEngine;

public class GoalComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Game_Manager gameManager =
                FindFirstObjectByType<Game_Manager>();

            if (gameManager != null)
            {
                gameManager.CompleteLevel();
            }
        }
    }
}
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            
            if(playerLives != null)
            {
                playerLives.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint reached!");
            }
        }
    }
}
using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public TMP_Text livesText;
    public int lives = 3;

    private WaypointMovement movement;
    private bool gameEnded;

    void Start()
    {
        movement = GetComponent<WaypointMovement>();
        UpdateLivesText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameEnded && collision.CompareTag("Obstacle"))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        if (gameEnded)
        {
            return;
        }

        lives = Mathf.Max(0, lives - 1);
        UpdateLivesText();

        if (lives == 0)
        {
            gameEnded = true;

            Game_Manager gameManager =
                FindFirstObjectByType<Game_Manager>();

            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            return;
        }

        if (movement != null)
        {
            movement.ResetToStart();
        }
    }

    public void StopLives()
    {
        gameEnded = true;
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
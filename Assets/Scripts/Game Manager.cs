using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public GameObject gameOverUI;
    public GameTimer gameTimer;

    private bool gameHasEnded = false;

    public void CompleteLevel()
    {
        if (gameHasEnded)
        {
            return;
        }

        gameHasEnded = true;
        levelCompleteUI.SetActive(true);
        StopGameplay();
    }

    public void GameOver()
    {
        if (gameHasEnded)
        {
            return;
        }

        gameHasEnded = true;
        gameOverUI.SetActive(true);
        StopGameplay();
    }

    void StopGameplay()
    {
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
        }

        WaypointMovement movement =
            FindFirstObjectByType<WaypointMovement>();

        if (movement != null)
        {
            movement.enabled = false;
        }

        PlayerLives playerLives =
            FindFirstObjectByType<PlayerLives>();

        if (playerLives != null)
        {
            playerLives.StopLives();
        }

        GameObject[] obstacles =
            GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
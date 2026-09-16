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

        GameObject obstacle =
            GameObject.FindGameObjectWithTag("Obstacle");

        if (obstacle != null)
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
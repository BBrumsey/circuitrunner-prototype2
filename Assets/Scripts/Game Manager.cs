using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public GameObject gameOverUI;


    private bool gameHasEnded = false;

    public void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverUI.SetActive(true);
        }

    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

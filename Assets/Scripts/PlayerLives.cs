using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public TMP_Text livesText;
    public int lives = 3;
    private Vector3 respawnPoint;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     respawnPoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
        UpdateLivesText();
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Lives remaining " + lives);
        UpdateLivesText();
        if (lives <= 0)
        {
            FindFirstObjectByType<Game_Manager>().GameOver();
        }
        else
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = respawnPoint;

        EnemyChase enemy = FindFirstObjectByType<EnemyChase>();
        if (enemy != null)
        {
            enemy.ResetEnemy();
        }
    }


    // Update is called once per frame
    void UpdateLivesText() 
    {
        livesText.text = "Lives: " + lives;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit the obstacle!");
            LoseLife();
        }
    }
}

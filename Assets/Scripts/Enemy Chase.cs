using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;

    }
    void Update()
    {
        if (player == null)
        {
            return;
        }
            Vector2 targetPosition = new Vector2(player.position.x, player.position.y);

            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
                );
        }

        public void ResetEnemy()
    {
        transform.position = startPosition;
    }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerLives playerLives = collision.gameObject.GetComponent<PlayerLives>();


                if (playerLives != null)
                {
                    playerLives.LoseLife();
                }
            }
        }
    }




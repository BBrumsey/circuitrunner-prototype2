using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalInput;

    private bool isGrounded;
    public float moveForce = 20f;

    public float jumpForce = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Zone"))
        {
            Debug.Log("Player died.");
            GetComponent<PlayerLives>().LoseLife();
        }
        
        if (collision.CompareTag("Goal"))
        {
            Debug.Log("Level Complete");
            FindFirstObjectByType<Game_Manager>().CompleteLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisonExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

        // Update is called once per frame
        void FixedUpdate()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(horizontalInput * moveForce, 0f));
        
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }


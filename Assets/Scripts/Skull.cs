using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;

    public float jumpForce = 9f;
    public bool isDead = false;

    GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       


    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainScene");
            }
        }


        else
        {
            rb.velocity = new Vector2(7.0f, rb.velocity.y);
            Vector2 velocity = rb.velocity;

            bool isJumping = animator.GetBool("Jump");

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                velocity.y += 9.0f;
                rb.velocity = velocity;
                animator.SetBool("Jump", true);
            }

            if (isJumping && rb.velocity.y <= 0.01f)
            {
                animator.SetBool("Jump", false);
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if(collision.gameObject.CompareTag("Demon"))
        {
            isDead = true;
            gameManager.GameOver();

        }
    }


}

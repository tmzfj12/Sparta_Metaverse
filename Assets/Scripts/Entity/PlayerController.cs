using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    SpriteRenderer spriteRenderer;
    public float speed = 4f;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        Vector2 move = new Vector2(moveX, moveY).normalized;

        rb.velocity = move * speed;

        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX <0)
        {
            spriteRenderer.flipX = true;
        }

        if(moveX != 0 || moveY != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -13f, 13f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 7.2f);
        transform.position = pos;
    }
}

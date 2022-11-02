using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    public float speed = 5f;
    public float jumpForce = 12f;
    private bool isFacingRight = true;
    bool IsGrounded = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Update()
    {

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));



        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsGrounded", false);
            IsGrounded =false;
        }
        

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsGrounded == true)
        {
            animator.SetBool("IsGrounded", true);
        }


        Flip();

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsCrouch", true);
            speed = 0;
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsCrouch", false);
            speed = 5f;

        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    /*public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

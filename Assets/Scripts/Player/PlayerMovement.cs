using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from this video: https://www.youtube.com/watch?v=K1xZ-rycYY8
// This for mouse look: https://www.youtube.com/watch?v=DPqc7qYDtzM
public class PlayerMovement : MonoBehaviour
{
    // Values for horizontal input, player speed, jump height, and whether or not they are facing right
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private bool facingRight = true;

    // Reference the components in Unity
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        // Parses return value of Input.GetAxisRaw Horizontal into variable, giving either -1, 0, or 1 depending on direction
        horizontal = Input.GetAxisRaw("Horizontal");

        // Jumps if player is grounded
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // Allows the player to jump higher by holding button down, or lower by tapping
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
        }

        //Flip();
    }

    // Set x component of rigidbody's velocity to horizontal input multiplied by speed
    private void FixedUpdate()
    {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // Checks if player is grounded by setting position of ground check, small radius, and if it collides with groundLayer
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    // PROBABLY DON'T NEED FOR PROJECT SINCE WE ARE LOOKING FOR 360* LOOKING VIA MOUSE INPUT
    private void Flip()
    {
        // Flips player based on direction they are moving by multiplying x component of player's local scale by -1
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
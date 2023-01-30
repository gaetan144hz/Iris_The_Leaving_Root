using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    public float speed;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>().x;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isGrounded == true)
        {
            rb.velocity = new Vector2(moveInput * speed, jumpForce);
            isGrounded = false;
        }
    }
}

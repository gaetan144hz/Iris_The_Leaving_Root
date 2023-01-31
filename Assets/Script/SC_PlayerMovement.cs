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
    private SC_GrabCompenent grabTarget;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<SC_GrabCompenent>(out grabTarget))
            return;
    }

    public void TryGrab(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            lineRenderer.SetPosition(1, grabTarget.joint.transform.position);
            lineRenderer.enabled = true;
            grabTarget.Grab(rb);
        }

        if (ctx.canceled)
        {
            lineRenderer.enabled = false;
            grabTarget.CancelGrab();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerMovement : MonoBehaviour
{
    [Header("Raycast")]
    public Queue<RaycastHit2D> _raycastQueue;
    [SerializeField] private float[] raycastMaxDistance;
    [SerializeField] private LayerMask _layerMask;

    [Header("Mouvement")] 
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private float moveInput;
    public float speed;
    public float jumpForce;

    public bool isGrounded;
    private SC_GrabCompenent grabTarget;
    private LineRenderer lineRenderer;
    private bool isGrab;
    private bool inTrigger;
    [SerializeField] private Color playerColor;

    private void Awake()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        _raycastQueue = new Queue<RaycastHit2D>();
    }

    private void Start()
    {
        animator.Play("spawn");
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
        
        if(grabTarget != null)
        {
            lineRenderer.SetPosition(1, grabTarget.joint.transform.position);
        }

        var raycast = Physics2D.Raycast(transform.position, transform.up, raycastMaxDistance[0], _layerMask);
        Debug.DrawRay(transform.position, transform.up * raycastMaxDistance[0], Color.magenta);

        _raycastQueue.Enqueue(raycast);
        Debug.Log(raycast);//rajoute le resulat d un raycast a la file d'attente
        // rajout de raycast, tabeau de vector2/distance pour les modifiés un par un les valeurs

        while (_raycastQueue.Count > 0) //tant que'il y a plus de 0 element dans la file d'attente 
        {
            var result = _raycastQueue.Dequeue(); //on recupere le prochaine element de la file d'attente
                
            if (result.collider != null)
            {
                Debug.Log("isGrounded" + isGrounded);
                isGrounded = true;
            }
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>().x;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput < 0)
        {
            sprite.flipX = true;
        }
        else if(moveInput > 0)
        {
            sprite.flipX = false;
        }

        if (ctx.canceled)
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isGrounded == true)
        {
            animator.Play("jump");
            rb.velocity = new Vector2(moveInput * speed, jumpForce);
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;

        if (grabTarget == null)
        {
            collision.TryGetComponent<SC_GrabCompenent>(out grabTarget);
        }
        else return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;

        if(isGrab == false)
        {
            grabTarget = null;
        }
    }
    public void TryGrab(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && grabTarget != null && isGrab == false)
        {
            lineRenderer.SetColors(playerColor, grabTarget.flowerColor);
            lineRenderer.SetPosition(1, grabTarget.joint.transform.position);
            lineRenderer.enabled = true;
            grabTarget.Grab(rb);
            isGrab = true;
        }

        if (ctx.canceled && grabTarget != null)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            lineRenderer.enabled = false;
            grabTarget.CancelGrab();
            isGrab = false;

            if(grabTarget != null && inTrigger == false)
            {
                grabTarget = null;
            }
        }
    }
}

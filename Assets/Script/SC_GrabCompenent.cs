using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    private Color baseColor;
    private bool isTrigger;
    public Joint2D joint;
    private SpriteRenderer sprite;
    private Rigidbody2D playerRb;
    private LineRenderer lineRenderer;
    public GameObject player;
    private Vector3 playerPos;

    private void Awake()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        lineRenderer = player.GetComponent<LineRenderer>();
        baseColor = sprite.color;
        lineRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            isTrigger = true;
            sprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            isTrigger = false;
            sprite.color = baseColor;
        }
    }

    private void Update()
    {
        playerPos = player.transform.position;
        lineRenderer.SetPosition(0, playerPos);
        lineRenderer.SetPosition(1, joint.transform.position);
    }

    public void Grab(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isTrigger == true)
        {
            lineRenderer.enabled = true;
            Debug.Log("Grab");
            joint.connectedBody = playerRb;
        }

        if(ctx.canceled && joint.connectedBody != null)
        {
            lineRenderer.enabled = false;
            Debug.Log("Grab_Canceled");
            joint.connectedBody = null;
        }
    }
}

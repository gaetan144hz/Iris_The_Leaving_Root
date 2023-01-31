using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    private Color baseColor;
    public Joint2D joint;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        baseColor = sprite.color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            sprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            sprite.color = baseColor;
        }
    }

    public void Grab(Rigidbody2D rb)
    {
        joint.connectedBody = rb;
    }

    public void CancelGrab()
    {
        if(joint.connectedBody == null)
            return;

        joint.connectedBody = null;
    }
}

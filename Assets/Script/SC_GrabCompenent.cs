using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color baseColor;
    private bool IsMouseOver;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        baseColor = sprite.color;
    }

    private void OnMouseEnter()
    {
        IsMouseOver = true;
        sprite.color = Color.red;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
        sprite.color = baseColor;
    }

    public void Grab(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && IsMouseOver)
        {
            Debug.Log("Grab");
        }

        if(ctx.canceled)
        {
            Debug.Log("Grab_Canceled");
        }
    }
}

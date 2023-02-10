using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    [Header("Joint2D")]
    public Joint2D joint;
    
    [Header("Sprite")]
    public SpriteRenderer rockSprite;
    [SerializeField] private Sprite newRockSprite;
    [SerializeField] private Sprite oldRockSprite;
    
    [Header("Color")]
    public Color flowerColor;
    
    [Header("Rigidbody")]
    private Rigidbody2D rbRock;
    public Rigidbody2D rb;

    public void Grab(Rigidbody2D rb)
    {
        if (this.gameObject.CompareTag("Pull"))
        {
            rbRock = this.GetComponent<Rigidbody2D>();
            rbRock.bodyType = RigidbodyType2D.Dynamic;
            rockSprite.sprite = newRockSprite;
            joint.connectedBody = rb;
            joint.enabled = true;
        }
        else
        {
            rockSprite.sprite = newRockSprite;
            joint.connectedBody = rb;
            joint.enabled = true;
        }
        
    }

    public void CancelGrab()
    {
        if(joint.connectedBody != null)
        {
            if (this.gameObject.CompareTag("Pull"))
            {
                rbRock.velocity = Vector2.zero;
                rbRock.bodyType = RigidbodyType2D.Kinematic;
                rockSprite.sprite = oldRockSprite;
                joint.connectedBody = null;
                joint.enabled = false;
            }else
            {
                rockSprite.sprite = oldRockSprite;
                joint.connectedBody = null;
                joint.enabled = false;
            }
        }
    }
}

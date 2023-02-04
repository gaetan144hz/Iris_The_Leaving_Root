using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    public Joint2D joint;
    public SpriteRenderer rockSprite;
    [SerializeField] private Sprite newRockSprite;
    [SerializeField] private Sprite oldRockSprite;
    public Color flowerColor;
    private Rigidbody2D rbRock;

    private void Start()
    {
        rbRock = this.GetComponent<Rigidbody2D>();

        rbRock.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Grab(Rigidbody2D rb)
    {
        rbRock.bodyType = RigidbodyType2D.Dynamic;
        rockSprite.sprite = newRockSprite;
        joint.connectedBody = rb;
        joint.enabled = true;
    }

    public void CancelGrab()
    {
        if(joint.connectedBody != null)
        {
            rbRock.velocity = Vector2.zero;
            rbRock.bodyType = RigidbodyType2D.Kinematic;
            rockSprite.sprite = oldRockSprite;
            joint.connectedBody = null;
            joint.enabled = false;
        }
    }
}

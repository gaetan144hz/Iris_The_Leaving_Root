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

    public void Grab(Rigidbody2D rb)
    {
        rockSprite.sprite = newRockSprite;
        joint.connectedBody = rb;
        joint.enabled = true;
    }

    public void CancelGrab()
    {
        if(joint.connectedBody != null)
        {
            rockSprite.sprite = oldRockSprite;
            joint.connectedBody = null;
            joint.enabled = false;
        }
    }
}

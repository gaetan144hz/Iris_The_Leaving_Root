using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_GrabCompenent : MonoBehaviour
{
    public Joint2D joint;

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

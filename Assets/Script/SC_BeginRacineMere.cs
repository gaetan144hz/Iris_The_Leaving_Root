using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class SC_BeginRacineMere : MonoBehaviour
{
    private PathFollower pathFollower;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        pathFollower = FindObjectOfType<PathFollower>();
        pathFollower.canKill = true;
    }
}

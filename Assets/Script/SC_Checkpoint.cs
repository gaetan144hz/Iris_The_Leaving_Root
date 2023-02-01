using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Checkpoint : MonoBehaviour
{
    private Transform playerPosition;

    void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        Debug.Log("checkpoint!");
        playerPosition.position = transform.position;
        Debug.Log(playerPosition.position);
        Destroy(this.gameObject);
    }
}

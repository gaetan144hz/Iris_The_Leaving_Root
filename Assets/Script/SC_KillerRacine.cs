using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_KillerRacine : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        Destroy(col.gameObject);
        Debug.Log(col.gameObject);
    }
}

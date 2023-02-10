using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SC_DeathZone : MonoBehaviour
{
    [SerializeField] public Transform checkPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator fadeSys;

    void Start()
    {
        //checkPoint = FindObjectOfType<SC_Checkpoint>().transform;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        fadeSys.SetTrigger("FadeIn");
        col.gameObject.transform.position = checkPoint.position;
        Debug.Log(checkPoint.position);
    }
}

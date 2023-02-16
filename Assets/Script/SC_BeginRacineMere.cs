using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using PathCreation.Examples;
using UnityEngine;

public class SC_BeginRacineMere : MonoBehaviour
{
    private PathFollower pathFollower;
    public GameObject textRun;
    public float timeBeforeSwitch;
    public float timeToWatch;
    public CinemachineVirtualCamera cam;
    public bool startCoro;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        pathFollower = FindObjectOfType<PathFollower>();
        startCoro = true;
        pathFollower.canKill = true;
        StartCoroutine(begin());
    }

    IEnumerator begin()
    {
        while (startCoro)
        {
            yield return new WaitForSeconds(timeBeforeSwitch);
            cam.Priority = 11;
            textRun.SetActive(true);
            yield return new WaitForSeconds(timeToWatch);
            cam.Priority = 9;
            textRun.SetActive(false);
            startCoro = false;
            Destroy(this.gameObject);
        }
    }
}

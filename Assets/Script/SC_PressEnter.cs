using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PressEnter : MonoBehaviour
{
    public GameObject pressEnter;
    private bool activated;
    [SerializeField] private float waitingTime;

    private void Awake()
    {
        activated = true;
    }

    void Start()
    {
        StartCoroutine(onPressEnter());
    }

    void Update()
    {
        if (activated)
            return;
        StopCoroutine(onPressEnter());
    }

    IEnumerator onPressEnter()
    {
        while (activated)
        {
            yield return new WaitForSeconds(waitingTime);
            pressEnter.SetActive(true);
        }
        activated = false;
    }
}

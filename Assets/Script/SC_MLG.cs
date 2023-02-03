using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SC_MLG : MonoBehaviour
{
    [SerializeField] private bool mlg;
    private Light2D light;
    [SerializeField] private float epilepsy;

    private void Awake()
    {
        mlg = true;
        light = this.GetComponent<Light2D>();
    }

    void Start()
    {
        StartCoroutine(onMLG());
    }

    void Update()
    {
        
    }

    public IEnumerator onMLG()
    {
        while (mlg)
        {
            light.intensity = 1;
            yield return new WaitForSeconds(epilepsy);
            light.intensity = 0;
        }
    }
}

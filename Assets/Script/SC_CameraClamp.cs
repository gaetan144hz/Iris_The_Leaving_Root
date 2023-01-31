using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraClamp : MonoBehaviour
{
    [SerializeField] private Transform targetFollow;
    
    [Header("Clamp X")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    [Header("Clamp Y")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetFollow.position.x, minX, maxX),
            Mathf.Clamp(targetFollow.position.y, minY, maxY),
            transform.position.z);
    }
}
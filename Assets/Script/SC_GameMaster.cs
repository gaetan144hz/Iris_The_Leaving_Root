using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameMaster : MonoBehaviour
{
    private static SC_GameMaster instance;
    public Vector2 lastCheckpointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

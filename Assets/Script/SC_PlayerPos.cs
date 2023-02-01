using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerPos : MonoBehaviour
{
    private SC_GameMaster _scGameMaster;
    void Start()
    {
        _scGameMaster = FindObjectOfType<SC_GameMaster>();
    }

    void Update()
    {
        
    }
}

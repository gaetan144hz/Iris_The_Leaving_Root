using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_MenuOnOff : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        
    }

    public void onMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            menu.SetActive(true);
        }

    }

    public void offMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            menu.SetActive(false);
        }
    }
}

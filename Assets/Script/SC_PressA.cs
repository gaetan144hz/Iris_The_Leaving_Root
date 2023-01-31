using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SC_PressA : MonoBehaviour
{
    [SerializeField] private string sceneNumber;

    public void pressA(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}

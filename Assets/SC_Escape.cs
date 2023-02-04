using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Escape : MonoBehaviour
{
    public GameObject escapeScreen;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            escapeScreen.SetActive(true);
        }
    }
}

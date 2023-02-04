using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SlideMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private bool moveRight;

    [SerializeField] private float rangeRight;
    [SerializeField] private float rangeLeft;

    void Start()
    {
        //moveSpeed = 2f;
        moveRight = true;
    }

    void Update()
    {
        if (transform.position.x > rangeRight)
        {
            moveRight = false;
        }
        else if (transform.position.x < rangeLeft)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}

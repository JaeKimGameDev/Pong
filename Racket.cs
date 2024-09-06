using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Racket : MonoBehaviour
{
    public float movementSpeed=800f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, 1) * movementSpeed;
        }
        else if(Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -1) * movementSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0) * movementSpeed;
        }
    }
}

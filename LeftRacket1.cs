using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRacket1 : MonoBehaviour
{
    public float movementSpeed;

    public void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}

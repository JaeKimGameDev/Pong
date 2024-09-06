using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody2D rb;
    public float movementSpeed = 800;
    public float aiDeadSpot = 75;
    int direction = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AIMovement();
    }
    public void AIMovement()
    {
        Vector2 ballPos = ball.transform.position;
        if (Mathf.Abs(ballPos.y - transform.position.y) > aiDeadSpot)
        {
            direction = ballPos.y > transform.position.y ? 1 : -1;
        }
        if (direction > 0)
        {
            rb.velocity = new Vector2(0, 1) * movementSpeed;
        }
        else if (direction < 0)
        {
            rb.velocity = new Vector2(0, -1) * movementSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0) * movementSpeed;
        }
    }
}
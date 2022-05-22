using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 3.0f;

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = .7f;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float TurnSpeed = 10.0f;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 pointingDir = transform.up;
        
        rb.AddForce(pointingDir * MoveSpeed * yDir);
        
        rb.AddTorque(TurnSpeed * -xDir);
    }
}

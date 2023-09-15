using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float TurnSpeed = 10.0f;

    public float LaserForce = 4.0f;

    public GameObject LaserPrefab;

    public float LaserCooldown = 0.05f;

    float laserTimer = 0.0f;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FireLaser()
    {
        GameObject obj = Instantiate(LaserPrefab, transform.position, transform.rotation);
            
        Rigidbody2D laserRB = obj.GetComponent<Rigidbody2D>();
        
        Physics2D.IgnoreCollision(
                this.GetComponent<Collider2D>(),
                obj.GetComponent<Collider2D>()
            );

        laserRB.AddForce(transform.up * LaserForce, ForceMode2D.Impulse);

        laserTimer = LaserCooldown;
    }

    void Update()
    {
        if (laserTimer > 0.0f)
            laserTimer -= Time.deltaTime;

        bool shoot = Input.GetButtonDown("Shoot");
        if (laserTimer <= 0.0f && shoot)
        {
            FireLaser();
        }
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

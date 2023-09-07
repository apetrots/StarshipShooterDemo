using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        transform.position += new Vector3(
            -xDir * MoveSpeed * Time.deltaTime, 
            yDir * MoveSpeed * Time.deltaTime,
            0.0f
            );
        
        //Vector3 newPos = transform.position;
        
        //newPos.x += xDir * MoveSpeed * Time.deltaTime;
        //newPos.y += yDir * MoveSpeed * Time.deltaTime;

        //transform.position = newPos;
    }
}

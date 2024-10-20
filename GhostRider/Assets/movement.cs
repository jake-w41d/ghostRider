using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform bike;
    public float speed;
    public float maxSpeed;
    public float acceleration;
    public float steeringSpeed;
    public bool isMoving;
    public bool leftMov;
    public bool rightMov;
    
    private Vector3 COM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        speed = 10f;
        maxSpeed = 30f;
        acceleration = 2f;
        steeringSpeed = 50f;
        
        isMoving = false;
        leftMov = false;
        rightMov = false;

    }
    void FixedUpdate()
    {
        Movement();
        Steering();
    }

    private void Movement()
    {
        if(isMoving == true)
        {
            if(speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
        }

        if(Input.GetKey("w"))
        {
            isMoving = true;
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else{ isMoving = false; }

    }

    private void Steering()
    {
        if(Input.GetKey("a"))
        {
            leftMov = true;
            transform.Rotate(0, -1, 0);
            transform.Translate(new Vector3(-0.5f, 0, 0) * speed * Time.deltaTime);
        }
        else{ leftMov = false; }
        
        if(Input.GetKey("d"))
        {
            rightMov = true;
            transform.Rotate(0, 1, 0);
            transform.Translate(new Vector3(0.5f, 0, 0) * speed * Time.deltaTime);
        }
        else{ rightMov = false; }
    }
}

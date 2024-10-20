using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotation : MonoBehaviour
{
    public Transform wheel;
    public Transform frontWheel;
    public bool move;

    public bool r_mov;
    public bool l_mov;
    public int maxWheelRotate;

    // Start is called before the first frame update
    void Start()
    {
        wheel = GetComponent<Transform>();
        frontWheel = GameObject.FindGameObjectWithTag("frontWheel").GetComponent<Transform>();
        move = false;
        r_mov = false;
        l_mov = false;
        maxWheelRotate = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = GameObject.Find("MotorBike").GetComponent<movement>().isMoving;
        r_mov = GameObject.Find("MotorBike").GetComponent<movement>().rightMov;
        l_mov = GameObject.Find("MotorBike").GetComponent<movement>().leftMov;

        if(move){ animWheel(); }
    }

    private void animWheel()
    {
        // spin wheels
        wheel.Rotate(new Vector3(10, 0, 0));

        // steer front wheel
        if(r_mov){ frontWheel.rotation = Quaternion.Slerp(frontWheel.rotation, Quaternion.Euler(0, 0, -maxWheelRotate), 0.05f); }
        if(l_mov){ frontWheel.rotation = Quaternion.Slerp(frontWheel.rotation, Quaternion.Euler(0, 0, maxWheelRotate), 0.05f); }
    }
}

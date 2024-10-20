using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikeRotation : MonoBehaviour
{
    public Transform bike;
    public bool r_mov;
    public bool l_mov;

    private float maxRotate = 30;

    // Start is called before the first frame update
    void Start()
    {
        bike = GetComponent<Transform>();
        r_mov = false;
        l_mov = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r_mov = GameObject.Find("MotorBike").GetComponent<movement>().rightMov;
        l_mov = GameObject.Find("MotorBike").GetComponent<movement>().leftMov;

        animBike();
    }

    private void animBike()
    {
        if(r_mov)
        { 
            //bike.Rotate(new Vector3(0, 0, -30)); 
            bike.rotation = Quaternion.Slerp(bike.rotation, Quaternion.Euler(0, 0, -maxRotate), 0.1f);
        }
        
        if(l_mov)
        { 
            //bike.Rotate(new Vector3(0, 0, 30)); 
            bike.rotation = Quaternion.Slerp(bike.rotation, Quaternion.Euler(0, 0, maxRotate), 0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform cameraObj;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraObj.position = player.position + offset;
    }
}

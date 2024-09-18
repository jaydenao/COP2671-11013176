using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 12.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Gather directional inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Move the vehical forward or backwards depending on input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //Rotate the vehicle left or right depending on input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    public float speed = 50;
    private float upperBound = 175;
    private float lowerBound = -230;
    private GameManager gameManager;
    private Rigidbody rb;

    Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            return;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(-Vector3.forward * horizontalInput * Time.deltaTime * 10000 ,ForceMode.Acceleration);
        
        if ( transform.position.z  < lowerBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,lowerBound);
           
        }
        else if (transform.position.z > upperBound )
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,upperBound);
        }
        else
        {
           
        }
        
        
        
       
    }
}

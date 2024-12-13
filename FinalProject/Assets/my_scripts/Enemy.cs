using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(100,200)]
    public float maxSpeed = 50;

    public ParticleSystem crashEffect;
    private float speed;
    private GameManager gameManager;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        speed = Random.Range(75, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(-Vector3.right * speed * Time.deltaTime,ForceMode.Impulse);
        if (transform.position.x < -145)
        {
            Destroy(gameObject);
        }
    }

     private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(crashEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            gameManager.GameOver(false);
            
        }
    }


}

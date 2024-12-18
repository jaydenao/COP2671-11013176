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
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        
        if (collision.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            Instantiate(crashEffect, transform.position, Quaternion.identity);
            if (playerCombat.hasPowerup)
            {
                Destroy(gameObject);
                return;
            }
            audioSource.Play();
            Destroy(collision.gameObject);
            gameManager.GameOver(false);
            
        }
    }


}

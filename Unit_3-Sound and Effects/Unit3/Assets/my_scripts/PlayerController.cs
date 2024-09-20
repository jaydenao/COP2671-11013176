using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    public ParticleSystem smokeParticles;
    public ParticleSystem dirtParticles;

    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool gameOver = false;

 


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver )
        {
            audioSource.PlayOneShot(jumpSound);
            dirtParticles.Stop();
            animator.SetBool("Jump_trig", true);
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(crashSound);
            dirtParticles.Stop();
            smokeParticles.Play();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", Random.Range(1, 3));
            Debug.Log("Game Over!");
            gameOver = true;
        }
        
    }
}

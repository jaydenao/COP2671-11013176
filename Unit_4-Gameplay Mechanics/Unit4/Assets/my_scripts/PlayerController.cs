using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject focalPoint;
    public float speed = 2.5f;

    public GameObject powerupIndicator;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            hasPowerup = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
            enemyRb.AddForce(pushDirection * powerupStrength,ForceMode.Impulse);
            Debug.Log($"Collided against enemy with powerup set to {hasPowerup}");
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        Debug.Log("Starting Countdown...");
        yield return new WaitForSeconds(7);
        Debug.Log("Disabling Powerup");
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}

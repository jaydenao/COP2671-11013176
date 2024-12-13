using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    private GameManager gameManager;
    public float speed;
    public ParticleSystem hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.right * speed * 500 * Time.deltaTime,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.Play();
            Instantiate(hitEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            gameManager.UpdateScore();
            
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


}

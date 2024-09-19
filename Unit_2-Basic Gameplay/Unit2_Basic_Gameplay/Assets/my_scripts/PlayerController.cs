using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float bounds = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        if (transform.position.x > bounds )
        {
            transform.position = new Vector3(bounds,transform.position.y,transform.position.z);
        }
        else if (transform.position.x < -bounds )
        {
            transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
        }
    }
}

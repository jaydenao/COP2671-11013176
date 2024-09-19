using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField]
    float forwardBounds;
    [SerializeField]
    float backBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > forwardBounds || transform.position.z < backBounds)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Powerup : MonoBehaviour
{
    private bool pickedUp;
    private PlayerCombat playerCombat;
    private MeshRenderer meshRenderer;
    public GameObject pointLight;
    
    public int duration = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(BeginDespawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerCombat.hasPowerup)
            {
                pickedUp = true;
                meshRenderer.enabled = false;
                pointLight.SetActive(false);   
                playerCombat.StartPowerupSession(duration);
                Debug.Log("powerup picked up");
            }
          
        }
    }

    IEnumerator BeginDespawn()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        if (!pickedUp)
        {
            Destroy(gameObject);
        }
    }

   
}

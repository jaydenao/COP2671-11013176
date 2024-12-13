using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject laser;
    public GameObject shotPoint;
    public GameObject[] trifecta;
    public GameObject powerupIndicator;
    public bool hasPowerup = false;
    

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
          gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasPowerup)
            {
                foreach (GameObject shotPoint in trifecta)
                {
                    GameObject.Instantiate(laser, shotPoint.transform.position, shotPoint.transform.rotation);
                }
            }
            else
            {
                GameObject.Instantiate(laser, shotPoint.transform.position, Quaternion.identity);
            }
            
        }
    }

    public void StartPowerupSession(int duration)
    {
        hasPowerup = true;
        powerupIndicator.SetActive(true);
        StartCoroutine(EnablePowerup(duration));
   
    }
    private IEnumerator EnablePowerup(int duration)
    {
        yield return new WaitForSeconds(duration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}

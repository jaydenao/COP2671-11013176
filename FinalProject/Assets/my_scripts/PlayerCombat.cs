using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject laser;
    public GameObject shotPoint;

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
            GameObject.Instantiate(laser,shotPoint.transform.position,Quaternion.identity);
        }
    }
}

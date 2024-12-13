using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button btn;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(gameManager.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

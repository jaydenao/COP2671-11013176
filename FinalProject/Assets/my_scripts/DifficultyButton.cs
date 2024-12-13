using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private Button btn;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        btn.onClick.AddListener(StartGameWithDiff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGameWithDiff()
    {
       gameManager.StartGame(difficulty);
    }
}

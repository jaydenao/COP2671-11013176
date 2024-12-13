using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject enemyPrefab;
    public float spawnRate = 2.0f;
    
    private float upperBound = 175;
    private float lowerBound = -230;

    public bool isGameActive = false;
    private bool gameStarted = false;
    public int score = 0;
    public int timeRemaining = 60;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public GameObject gameScreen;

    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseScreen.SetActive(!pauseScreen.activeInHierarchy);
            if (pauseScreen.activeInHierarchy)
            {
                isGameActive = false;
            }
            else
            {
                isGameActive = true;
                StartCoroutine(SpawnEnemy());
                StartCoroutine(ElapseTime());
            }
        }
    }

    public void StartGame(int difficulty)
    {
        gameStarted = true;
        GameObject.Find("StartMenu").SetActive(false);
        gameScreen.SetActive(true);
        spawnRate /= difficulty;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(ElapseTime());
    }

    public void GameOver(bool didWin)
    {
        isGameActive = false;
        if (didWin)
        {

        }
        else
        {

        }
    }

    IEnumerator SpawnEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector3 spawnLocation = new Vector3(enemySpawner.transform.position.x, 0, Random.Range(lowerBound, upperBound));
            Instantiate(enemyPrefab,spawnLocation,enemyPrefab.transform.rotation);

        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    IEnumerator ElapseTime()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(1);
            timeRemaining -= 1;
            timeText.text = $"Time Remaining: {timeRemaining}";
            if (timeRemaining <= 0)
            {
                GameOver(true);
            }
        }
    }
}

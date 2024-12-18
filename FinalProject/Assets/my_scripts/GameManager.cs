using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject enemyPrefab;

    public GameObject powerup;
    public GameObject powerupSpawner;

    public float spawnRate = 2.0f;
    public float powerupSpawnRate = 5.0f;
    
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
           PauseGame();
        }
    }

    public void StartGame(int difficulty)
    {
        gameStarted = true;
        GameObject.Find("StartMenu").SetActive(false);
        gameScreen.SetActive(true);
        spawnRate /= difficulty;
        scoreText.text = "Score: 0";
        StartAllCoroutines();
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(!pauseScreen.activeInHierarchy);
        if (pauseScreen.activeInHierarchy)
        {
            isGameActive = false;
        }
        else
        {
            isGameActive = true;
            StartAllCoroutines();
        }
    }

    public void GameOver(bool didWin)
    {
        isGameActive = false;
        if (didWin)
        {
            winScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    IEnumerator SpawnPowerup()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(powerupSpawnRate);
            Vector3 spawnLocation = new Vector3(powerupSpawner.transform.position.x, 0, Random.Range(lowerBound + 10, upperBound - 10));
            Instantiate(powerup, spawnLocation, powerup.transform.rotation);

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

    public void StartAllCoroutines()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(ElapseTime());
        StartCoroutine(SpawnPowerup());
    }
}

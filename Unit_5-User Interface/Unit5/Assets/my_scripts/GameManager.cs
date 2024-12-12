using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;
    public Button restartBtn;
    public TextMeshProUGUI gameOverText;

    public GameObject titleScreen;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
       
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

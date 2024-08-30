using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startLevel;
    public GameObject obstacle;
    public GameObject player;
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    public GameObject tryAgainPanel;
    public GameObject nextLevelPanel;
    int score = 0;
    bool gameOver = false;

    private void Start()
    {
        bool gameStarted = PlayerPrefs.GetInt("GameStarted", 0) == 1; // gameStarted = 1 if get back value 1

        if (gameStarted)
        {
            // If the game has been started, deactivate the start level
            startLevel.SetActive(false);
            GameStart();
        }
        else
        {
            // If the game has not been started yet, activate the start level
            startLevel.SetActive(true);
        }
    }

    IEnumerator SpawnObstacles() // wait time then spawn 
    {
        while (!gameOver)
        {
            float waitTime = Random.Range(0.6f, 1.3f);

            yield return new WaitForSeconds(waitTime);

            if (!gameOver)
            {
                GameObject spawnedObstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);

                Obstacle obstacleScript = spawnedObstacle.GetComponent<Obstacle>();
                if (obstacleScript != null)
                {
                    obstacleScript.SetGameManager(this);
                }
            }

        }
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();

        if (score >= 15)
        {
            // Save a flag indicating completion of the current level
            PlayerPrefs.SetInt("UnlockedLevel", 2);
            PlayerPrefs.Save();
        }
    }

    public void GameStart()
    {
        player.SetActive(true);
        startLevel.SetActive(false);
        StartCoroutine("SpawnObstacles");

        PlayerPrefs.SetInt("GameStarted", 1);
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        if (score >= 15)
        {
            nextLevelPanel.SetActive(true);
        }

        else
        {
            tryAgainPanel.SetActive(true);
        }

        gameOver = true;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }

    public void RestartLevel()
    {
        
    }
}

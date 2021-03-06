﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    public int hazardCount;
    public float spawnWait;
    public float waveWait;
    private GameObject Asteroid;
    private Mover hazardScript;
    public Text scoreText;
    private int score;
    public Text gameOverText;
    public Text restartText;
    private bool gameOver;
    private bool restart;

    private void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        restart = false;
        score = 0;
        UpdateScore();
        hazardScript = hazard.GetComponent<Mover>();
        hazardScript.speed = -5.0f;
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            restartText.text = "Press 'R' to restart";
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y, spawnValues.z);
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            hazardCount++;
            hazardScript.speed = hazardScript.speed * 1.1f;
            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }
    
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int points)
    {
        string debugText = string.Format("Adding {0} points", points);
        Debug.Log(debugText);
        score += points;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GAME OVER";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        score = 0;
        UpdateScore();
        hazardScript = hazard.GetComponent<Mover>();
        hazardScript.speed = -5.0f;
        StartCoroutine(SpawnWaves());
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
}

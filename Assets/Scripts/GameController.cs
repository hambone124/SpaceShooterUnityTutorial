using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        hazardScript = hazard.GetComponent<Mover>();
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

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private int initialEnemyWave = 1;
    [SerializeField] private float spawnRange = 9.0f;

    private int currentWave;
    private int enemiesInGame;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = initialEnemyWave;
        SpawnEnemyWave(currentWave);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesInGame = FindObjectsOfType<Enemy>().Length;
        if (enemiesInGame == 0)
        {
            currentWave++;
            SpawnEnemyWave(currentWave);
            SpawnPowerUp();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(randomX, 0, randomZ);
    }
}

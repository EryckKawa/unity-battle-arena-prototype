using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	private float spawnRange = 9.0f;
	// Start is called before the first frame update
	void Start()
	{
		Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
	}

	// Update is called once per frame
	void Update()
	{

	}
	
	private Vector3 GenerateRandomPosition()
	{
		float randomXRange = Random.Range(-spawnRange, spawnRange);
		float randomZRange = Random.Range(-spawnRange, spawnRange);

		Vector3 spawnPos = new Vector3(randomXRange, 0, randomZRange);

		return spawnPos;
	}
}

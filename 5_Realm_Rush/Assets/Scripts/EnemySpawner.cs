using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f, 5f)]
	[SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(RepeatedlySpawnEnemies());
	}
	
	IEnumerator RepeatedlySpawnEnemies()
	{
		while (true)
		{
			Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}

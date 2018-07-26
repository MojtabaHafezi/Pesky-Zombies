using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public GameObject zombiePrefab;
	private int spawnCounter;
	private float elapsed;
	private float interval;
	private Transform[] spawnPoints;

	// Use this for initialization
	void Start ()
	{
		elapsed = 0f;
		spawnCounter = 0;
		interval = 1;
		spawnPoints = GetComponentsInChildren <Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		elapsed += Time.deltaTime;
		if (elapsed > interval) {
			elapsed = 0;
			//Only if there are not too many zombies already
			if (spawnCounter < 120) {
				SpawnZombie ();
			}
		}
	}

	//Create a zombie randomly on one of the spawnPoints.
	void SpawnZombie ()
	{
		int random = Random.Range (1, spawnPoints.Length);
		Instantiate (zombiePrefab, spawnPoints [random].position, Quaternion.identity);
		spawnCounter++;
	}

}

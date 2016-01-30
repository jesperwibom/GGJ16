using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public int NumberOfEnemies;
	private int EnemyCounter;
	private bool bossSpawned;

	public Rigidbody2D enemy;
	public Rigidbody2D boss;
	public float interval = 2f;
	private Transform spawnPosition;
	private bool levelRunning = true;
	private Vector3 spawnPos;

	// Use this for initialization
	void Start () {
		spawnPosition  = gameObject.transform;
		StartCoroutine (Spawner());

	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyCounter > NumberOfEnemies + 1 && bossSpawned == false) {

			SpawnBoss ();

		}

	}

	private IEnumerator Spawner (){
		yield return new WaitForSeconds (interval);

		int randomY = Random.Range(-6, 5); 
		spawnPos = new Vector3 (spawnPosition.position.x, randomY, 4);

		Rigidbody2D enemyIns = Instantiate (enemy, spawnPos, spawnPosition.rotation) as Rigidbody2D; 
		EnemyCounter = EnemyCounter + 1;

		// fixed pos
		// Rigidbody2D enemyIns = Instantiate (enemy, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D; 
		if (bossSpawned == false) {
			StartCoroutine (Spawner());
		}

	}
	public void SpawnBoss(){
		Rigidbody2D bossIns = Instantiate (boss, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D; 
		StopAllCoroutines ();
		bossSpawned = true;
	}

}

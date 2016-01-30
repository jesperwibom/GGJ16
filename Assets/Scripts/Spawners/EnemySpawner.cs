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

	// Parallax layers reference
	public GameObject background;
	private ScrollScript backgroundScroller;

	public GameObject middleground;
	private ScrollScript middlegroundScroller;

	public GameObject forground;
	private ScrollScript forgroundScroller;

	// Use this for initialization
	void Start () {
		spawnPosition  = gameObject.transform;
		StartCoroutine (Spawner());

		// Parallax references
		backgroundScroller = background.GetComponent<ScrollScript> ();
		forgroundScroller = middleground.GetComponent<ScrollScript> ();
		middlegroundScroller = forground.GetComponent<ScrollScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyCounter == NumberOfEnemies) {


			// SpawnBoss ();
			backgroundScroller.stopScroll ();
			forgroundScroller.stopScroll ();
			middlegroundScroller.stopScroll ();
			if (bossSpawned == false) {
				StartCoroutine (BossSpawner ());
			}
		}

	}

	private IEnumerator Spawner (){
		yield return new WaitForSeconds (interval);

		int randomY = Random.Range(-3, 4); 
		spawnPos = new Vector3 (spawnPosition.position.x, randomY, 4);

		Rigidbody2D enemyIns = Instantiate (enemy, spawnPos, spawnPosition.rotation) as Rigidbody2D; 


		// fixed pos
		// Rigidbody2D enemyIns = Instantiate (enemy, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D; 
		if (bossSpawned == false && EnemyCounter < NumberOfEnemies) {
			StartCoroutine (Spawner());
		}
		EnemyCounter = EnemyCounter + 1;

	}
	private IEnumerator BossSpawner (){
		yield return new WaitForSeconds (8f);
		SpawnBoss ();
		StopAllCoroutines ();
	}
	public void SpawnBoss(){
		Rigidbody2D bossIns = Instantiate (boss, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D; 
		StopAllCoroutines ();
		bossSpawned = true;

	}
}
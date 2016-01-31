using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class EnemySpawner : MonoBehaviour {
	
	private GameObject bossDeathSound;

	public int NumberOfEnemies = 20;
	private int EnemyCounter;
	private bool bossSpawned;
	public GameObject[] enemyTypes;
	public string nextScene;

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

	// Sound related

	public AudioSource themesong;
	public AudioSource bosssong;
	void Start () {
		bossDeathSound = GameObject.FindGameObjectWithTag ("bossDeathSound");
		

		themesong.Play ();
		
		spawnPosition  = gameObject.transform;
		StartCoroutine (Spawner());

		// Parallax references
		backgroundScroller = background.GetComponent<ScrollScript> ();
		forgroundScroller = middleground.GetComponent<ScrollScript> ();
		middlegroundScroller = forground.GetComponent<ScrollScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		





	}

	private IEnumerator Spawner (){
		yield return new WaitForSeconds (interval);

		int arrayPos = Random.Range(0, enemyTypes.Length); 
		int randomY = Random.Range(-3, 4); 
		spawnPos = new Vector3 (spawnPosition.position.x, randomY, 4);
		enemy = enemyTypes [arrayPos].GetComponent<Rigidbody2D>();
		Rigidbody2D enemyIns = Instantiate (enemy, spawnPos, spawnPosition.rotation) as Rigidbody2D; 
		Debug.Log ("Spawned " + enemy);

		EnemyCounter = EnemyCounter + 1;
		Debug.Log("Nr of enemies:" + EnemyCounter);
		if (EnemyCounter <= NumberOfEnemies-1) {
			StartCoroutine (Spawner ());
		} else {
			StopAllCoroutines ();
			StartCoroutine (stopScrolls ());
		}

	}

	private IEnumerator stopScrolls (){
		yield return new WaitForSeconds (5);
		if (bossSpawned == false) {
			StartCoroutine (BossSpawner ());


			// SpawnBoss ();

			backgroundScroller.stopScroll ();
			forgroundScroller.stopScroll ();
			middlegroundScroller.stopScroll ();

		}
	}
	private IEnumerator BossSpawner (){
		yield return new WaitForSeconds (3);
		SpawnBoss ();
		StopAllCoroutines ();
	}
	public void SpawnBoss(){
		Rigidbody2D bossIns = Instantiate (boss, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D; 
		StopAllCoroutines ();
		bossSpawned = true;
		themesong.Stop();
		bosssong.Play ();

	}
	public void swapScene(){
		bosssong.Stop ();
		bossDeathSound.GetComponent<AudioSource> ().Play ();
		StartCoroutine (newScene ());
	}

	private IEnumerator newScene(){
		Debug.Log ("swap scene coroutine");
		yield return new WaitForSeconds (4.5f);
		EditorSceneManager.LoadScene (nextScene);
}
}

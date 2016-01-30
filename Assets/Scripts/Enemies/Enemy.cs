using UnityEngine;
using System.Collections;

//movement and life

public class Enemy : MonoBehaviour {
	private AudioSource entrySound;

	public float speed = 10f;
	public float life = 150f;

	public float maxLifeTime = 30f;
	private Rigidbody2D rb;

	// Scene swap related 
	private GameObject spawner;
	public bool boss;
	private EnemySpawner enemySpawner;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spawner = GameObject.FindGameObjectWithTag ("Spawner");
		enemySpawner = spawner.GetComponent<EnemySpawner> ();


		Debug.Log (entrySound);
		StartCoroutine (EntrySound ());
		Destroy (gameObject, maxLifeTime);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Travel ();
		CheckLife ();
	}

	void Travel(){
		Vector2 movement = new Vector2 (-speed * Time.deltaTime, 0);
		rb.MovePosition(rb.position + movement);
	}

	void CheckLife(){
		if (life <= 0) {
			if (boss) {
				enemySpawner.swapScene();

			}
			Destroy (gameObject);
		}
	}

	public void TakeDamage(float dmg){
		life -= dmg;
		Debug.Log ("Dmg taken : " + dmg);
		//play damage particle/animation
	}
	private IEnumerator EntrySound(){
		if(entrySound != null){
			Debug.Log ("playing entry sound");
			yield return new WaitForSeconds (2);
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}

}

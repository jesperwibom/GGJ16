using UnityEngine;
using System.Collections;

//use playermanager script to control player life, animation and death grunts

public class SimpleEnemyProjectile : MonoBehaviour {

	public float speed = 12f;
	public LayerMask playerMask;

	private float maxLifeTime = 2f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, maxLifeTime);
	}

	void OnTriggerEnter2D (Collider2D col){	
		//Debug.Log ("Hit!!!");

		if (col.IsTouching(gameObject.GetComponent<Collider2D>())) {

			Rigidbody2D rb = col.GetComponent<Rigidbody2D> ();

			PlayerManager player = rb.GetComponent<PlayerManager> ();
			if (player != null) {
				player.Hit ();
				Destroy (gameObject);
			}
			/*
			DespawnManager despawner = rb.GetComponent<DespawnManager> ();
			if (player != null) {
				Debug.Log ("Despawn");
				Destroy (gameObject);
			}*/
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Travel ();
	}

	void Travel(){
		Vector2 movement = new Vector2 (-speed * Time.deltaTime, 0);
		rb.MovePosition(rb.position + movement);
	}
}

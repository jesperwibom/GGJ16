using UnityEngine;
using System.Collections;

public class EnemyCollition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

		}

	}
}
